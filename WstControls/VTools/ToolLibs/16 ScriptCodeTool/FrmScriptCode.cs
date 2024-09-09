using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ScintillaNET;

namespace WstControls
{
    public partial class FrmScriptCode : Form
    {
        public FrmScriptCode()
        {
            InitializeComponent();
        }
        Scintilla mTextEdit;
        bool SearchIsOpen = false;
        string methodKey = "";
        dynamic ScriptObject;

        private const string key1 = " class extends implements import interface new case do while else if for in switch throw get set function var try catch finally while with default break continue " +
            "delete return each const namespace package include use is as instanceof typeof author copy default deprecated eventType example exampleText exception haxe inheritDoc internal link mtasc " +
            "mxmlc param private return see serial serialData serialField since throws usage version langversion playerversion productversion dynamic private public partial static intrinsic internal " +
            "native override protected AS3 final super this arguments null Infinity NaN undefined true false abstract as base bool break by byte case catch char checked class const continue decimal " +
            "default delegate do double descending explicit event extern else enum false finally fixed float for foreach from goto group if implicit in int interface internal into is lock long new " +
            "null namespace object operator out override orderby params private protected public readonly ref return switch struct sbyte sealed short sizeof stackalloc static string select this " +
            "throw true try typeof uint ulong unchecked unsafe ushort using var virtual volatile void while where yield";
        private const string key2 = "void Null ArgumentError arguments Array Boolean Class Date DefinitionError Error EvalError Function int Math Namespace Number Object RangeError ReferenceError " +
            "RegExp SecurityError String SyntaxError TypeError uint XML XMLList Boolean Byte Char DateTime Decimal Double Int16 Int32 Int64 IntPtr SByte Single UInt16 UInt32 UInt64 UIntPtr Void " +
            "Path File System Windows Forms ScintillaNET";
        private const string CustomKey = "Equals() GetHashCode() GetType() ToString() Length Count if(^)\n{\n} if(^)\n{\n}\nelse\n{\n} for(^;;)\n{\n} for(int i=0;i<^;i++)\n{\n} foreach(var i in ^)\n{\n} " +
            "while(^)\n{\n} do${\n^}while() switch(^)\n{\ncase:break;\n} WriteExceptionLog(^) WriteInfoLog(^) WriteErrorLog(^) DispObj(^) SetColor(^) SetDraw(^) SetTxtPosition(^,^) WriteString(^)";
        private string autoFinishString = key1 + " " + key2 + " " + CustomKey;

        public string AutoString
        {
            get
            {
                var temp = autoFinishString.Split(' ').ToList();
                temp.Sort();
                var tempStr = string.Join(" ", temp);
                return tempStr;
            }
        }

        private void FrmScriptCode_Load(object sender, EventArgs e)
        {
            mTextEdit = new Scintilla();
            mTextEdit.Parent = panel_CodeEdit;
            mTextEdit.Dock = DockStyle.Fill;

            mTextEdit.TextChanged += this.OnTextChanged;
            mTextEdit.CharAdded += this.ScEdit_CharAdded;
            mTextEdit.AutoCCompleted += AutoCCompleted;

            //初始化热键
            InitHotkeys(this);

            //初始化显示配置
            mTextEdit.WrapMode = WrapMode.None;
            mTextEdit.IndentationGuides = IndentView.LookBoth;

            //mTextEdit.AutoCIgnoreCase = true;
            //mTextEdit.AnnotationVisible = Annotation.Standard;



            // 显示样式
            InitColors();
            InitSyntaxColoring();
            //行号边距设定
            InitNumberMargin();

            // BOOKMARK MARGIN
            InitBookmarkMargin();


            // CODE FOLDING MARGIN
            InitCodeFolding();

            // DRAG DROP
            InitDragDropFile();
        }

        private void OnTextChanged(object sender, EventArgs e)
        {
            //ToolScriptCodeParam param = (ToolScriptCodeParam)tool.ToolParam;
            //param.mScriptCode = mTextEdit.Text;
            //tool.ToolParam = param;
        }

        private void AutoCCompleted(object sender, AutoCSelectionEventArgs e)
        {
            int pos = mTextEdit.CurrentPosition;
            if (mTextEdit.CurrentLine < 1)
            {
                return;
            }
            string[] Text = GetStringList();
            string txt = e.Text;
            string[] str = txt.Split('\n');

            ScintillaNET.Line line = mTextEdit.Lines[mTextEdit.CurrentLine - str.Length + 1];
            int start = line.Text.IndexOf(line.Text.TrimStart());


            if (str.Length > 1)
            {
                string ss = new string(' ', start);
                for (int i = 1; i < str.Count(); i++)
                {
                    mTextEdit.InsertText(mTextEdit.Lines[mTextEdit.CurrentLine + i + 1 - str.Length].Position, ss);
                }
            }
        }

        private void ScEdit_CharAdded(object sender, CharAddedEventArgs e)
        {

            // Find the word start
            var currentPos = mTextEdit.CurrentPosition;
            var wordStartPos = mTextEdit.WordStartPosition(currentPos, true);

            // Display the autocompletion list
            var lenEntered = currentPos - wordStartPos;
            if (lenEntered > 0)
            {
                methodKey = mTextEdit.Text.Substring(wordStartPos, lenEntered);
                if (methodKey != "")
                {
                    if (!mTextEdit.AutoCActive)
                    {
                        mTextEdit.AutoCShow(lenEntered, AutoString);
                    }
                }
            }
            AutoIndicator();
        }

        private string[] GetStringList()
        {
            string[] s = new string[] { "\n" };
            return mTextEdit.Text.Split(s, StringSplitOptions.None);
        }

        private void AutoIndicator()
        {
            int pos = mTextEdit.CurrentPosition;
            if (pos > 3 && mTextEdit.GetCharAt(pos - 1) == '\n' && mTextEdit.GetCharAt(pos - 2) == '\r')
            {
                string[] txt = GetStringList();
                bool na = txt[mTextEdit.CurrentLine].Contains("}");
                if (mTextEdit.GetCharAt(pos - 3) == '{' && !na)
                {
                    string[] Text = GetStringList();
                    string line = Text[mTextEdit.CurrentLine - 1];
                    int start = line.IndexOf(line.TrimStart());
                    string ss = line.Substring(0, start);
                    string str = new string(' ', 4);
                    mTextEdit.InsertText(pos, ss + str);
                    mTextEdit.SelectionStart = mTextEdit.SelectionEnd = pos + ss.Length + 4;
                }
                else
                {
                    string[] Text = GetStringList();
                    string line = Text[mTextEdit.CurrentLine - 1];
                    int start = line.IndexOf(line.TrimStart());
                    string ss = line.Substring(0, start);
                    mTextEdit.InsertText(pos, ss);
                    mTextEdit.SelectionStart = mTextEdit.SelectionEnd = pos + ss.Length;
                }

            }
        }

        private void InitHotkeys(Form form)
        {

            // register the hotkeys with the form
            HotKeyManager.AddHotKey(form, OpenSearch, Keys.F, true);
            HotKeyManager.AddHotKey(form, OpenFindDialog, Keys.F, true, false, true);
            HotKeyManager.AddHotKey(form, OpenReplaceDialog, Keys.R, true);
            HotKeyManager.AddHotKey(form, OpenReplaceDialog, Keys.H, true);
            HotKeyManager.AddHotKey(form, Uppercase, Keys.U, true);
            HotKeyManager.AddHotKey(form, Lowercase, Keys.L, true);
            HotKeyManager.AddHotKey(form, ZoomIn, Keys.Oemplus, true);
            HotKeyManager.AddHotKey(form, ZoomOut, Keys.OemMinus, true);
            HotKeyManager.AddHotKey(form, ZoomDefault, Keys.D0, true);
            HotKeyManager.AddHotKey(form, CloseSearch, Keys.Escape);

            // remove conflicting hotkeys from scintilla
            mTextEdit.ClearCmdKey(Keys.Control | Keys.F);
            mTextEdit.ClearCmdKey(Keys.Control | Keys.R);
            mTextEdit.ClearCmdKey(Keys.Control | Keys.H);
            mTextEdit.ClearCmdKey(Keys.Control | Keys.L);
            mTextEdit.ClearCmdKey(Keys.Control | Keys.U);
            mTextEdit.ClearCmdKey(Keys.Control | Keys.S);

        }

        private void OpenSearch()
        {

            SearchManager.SearchBox = TxtSearch;
            SearchManager.TextArea = mTextEdit;

            if (!SearchIsOpen)
            {
                SearchIsOpen = true;
                InvokeIfNeeded(delegate ()
                {
                    PanelSearch.Visible = true;
                    TxtSearch.Text = SearchManager.LastSearch;
                    TxtSearch.Focus();
                    TxtSearch.SelectAll();
                });
            }
            else
            {
                InvokeIfNeeded(delegate ()
                {
                    TxtSearch.Focus();
                    TxtSearch.SelectAll();
                });
            }
        }

        public void InvokeIfNeeded(Action action)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(action);
            }
            else
            {
                action.Invoke();
            }
        }

        private void OpenFindDialog()
        {

        }
        private void OpenReplaceDialog()
        {


        }
        private void Lowercase()
        {
            // save the selection
            int start = mTextEdit.SelectionStart;
            int end = mTextEdit.SelectionEnd;

            // modify the selected text
            mTextEdit.ReplaceSelection(mTextEdit.GetTextRange(start, end - start).ToLower());

            // preserve the original selection
            mTextEdit.SetSelection(start, end);
        }

        private void Uppercase()
        {
            // save the selection
            int start = mTextEdit.SelectionStart;
            int end = mTextEdit.SelectionEnd;

            // modify the selected text
            mTextEdit.ReplaceSelection(mTextEdit.GetTextRange(start, end - start).ToUpper());

            // preserve the original selection
            mTextEdit.SetSelection(start, end);
        }

        private void ZoomIn()
        {
            mTextEdit.ZoomIn();
        }

        private void ZoomOut()
        {
            mTextEdit.ZoomOut();
        }

        private void ZoomDefault()
        {
            mTextEdit.Zoom = 0;
        }
        private void CloseSearch()
        {
            if (SearchIsOpen)
            {
                SearchIsOpen = false;
                InvokeIfNeeded(delegate ()
                {
                    PanelSearch.Visible = false;
                    //CurBrowser.GetBrowser().StopFinding(true);
                });
            }
        }

        private void InitColors()
        {
            //设定选中文本颜色
            mTextEdit.SetSelectionBackColor(true, IntToColor(0x114D9C));
            mTextEdit.CaretForeColor = Color.White;
        }

        public static Color IntToColor(int rgb)
        {
            return Color.FromArgb(255, (byte)(rgb >> 16), (byte)(rgb >> 8), (byte)rgb);
        }

        private void InitSyntaxColoring()
        {
            // Configure the default style
            mTextEdit.StyleResetDefault();
            mTextEdit.Styles[Style.Default].Font = "Consolas";
            mTextEdit.Styles[Style.Default].Size = 10;
            mTextEdit.Styles[Style.Default].BackColor = IntToColor(0x212121);
            mTextEdit.Styles[Style.Default].ForeColor = IntToColor(0xFFFFFF);
            mTextEdit.StyleClearAll();

            // Configure the CPP (C#) lexer styles
            mTextEdit.Styles[Style.Cpp.Identifier].ForeColor = IntToColor(0xD0DAE2);
            mTextEdit.Styles[Style.Cpp.Comment].ForeColor = IntToColor(0xBD758B);
            mTextEdit.Styles[Style.Cpp.CommentLine].ForeColor = IntToColor(0x40BF57);
            mTextEdit.Styles[Style.Cpp.CommentDoc].ForeColor = IntToColor(0x2FAE35);
            mTextEdit.Styles[Style.Cpp.Number].ForeColor = IntToColor(0xFFFF00);
            mTextEdit.Styles[Style.Cpp.String].ForeColor = IntToColor(0xFFFF00);
            mTextEdit.Styles[Style.Cpp.Character].ForeColor = IntToColor(0xE95454);
            mTextEdit.Styles[Style.Cpp.Preprocessor].ForeColor = IntToColor(0x8AAFEE);
            mTextEdit.Styles[Style.Cpp.Operator].ForeColor = IntToColor(0xE0E0E0);
            mTextEdit.Styles[Style.Cpp.Regex].ForeColor = IntToColor(0xff00ff);
            mTextEdit.Styles[Style.Cpp.CommentLineDoc].ForeColor = IntToColor(0x77A7DB);
            mTextEdit.Styles[Style.Cpp.Word].ForeColor = IntToColor(0x48A8EE);
            mTextEdit.Styles[Style.Cpp.Word2].ForeColor = IntToColor(0xF98906);
            mTextEdit.Styles[Style.Cpp.CommentDocKeyword].ForeColor = IntToColor(0xB3D991);
            mTextEdit.Styles[Style.Cpp.CommentDocKeywordError].ForeColor = IntToColor(0xFF0000);
            mTextEdit.Styles[Style.Cpp.GlobalClass].ForeColor = IntToColor(0x48A8EE);

            mTextEdit.Lexer = Lexer.Cpp;

            mTextEdit.SetKeywords(0, key1);
            mTextEdit.SetKeywords(1, key2);
            mTextEdit.SetKeywords(2, CustomKey);

        }


        //编辑器背景颜色
        private const int BACK_COLOR = 0x2A211C;
        //字体颜色
        private const int FORE_COLOR = 0xB7B7B7;
        //行号显示的边距
        private const int NUMBER_MARGIN = 1;
        //书签和断点的样式
        private const int BOOKMARK_MARGIN = 2;
        private const int BOOKMARK_MARKER = 2;
        //代码折叠功能
        private const int FOLDING_MARGIN = 3;
        //是否显示代码折叠按钮（+/-）
        private const bool CODEFOLDING_CIRCULAR = true;

        private void InitNumberMargin()
        {

            mTextEdit.Styles[Style.LineNumber].BackColor = IntToColor(BACK_COLOR);
            mTextEdit.Styles[Style.LineNumber].ForeColor = IntToColor(FORE_COLOR);
            mTextEdit.Styles[Style.IndentGuide].ForeColor = IntToColor(FORE_COLOR);
            mTextEdit.Styles[Style.IndentGuide].BackColor = IntToColor(BACK_COLOR);

            var nums = mTextEdit.Margins[NUMBER_MARGIN];
            nums.Width = 30;
            nums.Type = MarginType.Number;
            nums.Sensitive = true;
            nums.Mask = 0;

            mTextEdit.MarginClick += mTextEdit_MarginClick;
        }

        private void mTextEdit_MarginClick(object sender, MarginClickEventArgs e)
        {
            if (e.Margin == BOOKMARK_MARGIN)
            {
                // Do we have a marker for this line?
                const uint mask = (1 << BOOKMARK_MARKER);
                var line = mTextEdit.Lines[mTextEdit.LineFromPosition(e.Position)];
                if ((line.MarkerGet() & mask) > 0)
                {
                    // Remove existing bookmark
                    line.MarkerDelete(BOOKMARK_MARKER);
                }
                else
                {
                    // Add bookmark
                    line.MarkerAdd(BOOKMARK_MARKER);
                }
            }
        }

        private void InitBookmarkMargin()
        {

            //mTextEdit.SetFoldMarginColor(true, IntToColor(BACK_COLOR));

            var margin = mTextEdit.Margins[BOOKMARK_MARGIN];
            margin.Width = 20;
            margin.Sensitive = true;
            margin.Type = MarginType.Symbol;
            margin.Mask = (1 << BOOKMARK_MARKER);
            //margin.Cursor = MarginCursor.Arrow;

            var marker = mTextEdit.Markers[BOOKMARK_MARKER];
            marker.Symbol = MarkerSymbol.Circle;
            marker.SetBackColor(IntToColor(0xFF003B));
            marker.SetForeColor(IntToColor(0x000000));
            marker.SetAlpha(100);

        }

        private void InitCodeFolding()
        {

            mTextEdit.SetFoldMarginColor(true, IntToColor(BACK_COLOR));
            mTextEdit.SetFoldMarginHighlightColor(true, IntToColor(BACK_COLOR));

            // Enable code folding
            mTextEdit.SetProperty("fold", "1");
            mTextEdit.SetProperty("fold.compact", "1");

            // Configure a margin to display folding symbols
            mTextEdit.Margins[FOLDING_MARGIN].Type = MarginType.Symbol;
            mTextEdit.Margins[FOLDING_MARGIN].Mask = Marker.MaskFolders;
            mTextEdit.Margins[FOLDING_MARGIN].Sensitive = true;
            mTextEdit.Margins[FOLDING_MARGIN].Width = 20;

            // Set colors for all folding markers
            for (int i = 25; i <= 31; i++)
            {
                mTextEdit.Markers[i].SetForeColor(IntToColor(BACK_COLOR)); // styles for [+] and [-]
                mTextEdit.Markers[i].SetBackColor(IntToColor(FORE_COLOR)); // styles for [+] and [-]
            }

            // Configure folding markers with respective symbols
            mTextEdit.Markers[Marker.Folder].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CirclePlus : MarkerSymbol.BoxPlus;
            mTextEdit.Markers[Marker.FolderOpen].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CircleMinus : MarkerSymbol.BoxMinus;
            mTextEdit.Markers[Marker.FolderEnd].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CirclePlusConnected : MarkerSymbol.BoxPlusConnected;
            mTextEdit.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
            mTextEdit.Markers[Marker.FolderOpenMid].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CircleMinusConnected : MarkerSymbol.BoxMinusConnected;
            mTextEdit.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
            mTextEdit.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;

            // Enable automatic folding
            mTextEdit.AutomaticFold = (AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change);

        }


        #region 拖拽文本

        public void InitDragDropFile()
        {
            mTextEdit.AllowDrop = true;
            mTextEdit.DragEnter += delegate (object sender, DragEventArgs e)
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                    e.Effect = DragDropEffects.Copy;
                else
                    e.Effect = DragDropEffects.None;
            };
            mTextEdit.DragDrop += delegate (object sender, DragEventArgs e)
            {
                // get file drop
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    Array a = (Array)e.Data.GetData(DataFormats.FileDrop);
                    if (a != null)
                    {
                        string path = a.GetValue(0).ToString();
                        LoadDataFromFile(path);
                    }
                }
            };

        }

        private void LoadDataFromFile(string path)
        {
            if (File.Exists(path))
            {
                mTextEdit.Text = File.ReadAllText(path);
            }
        }

        #endregion

        private void button_Compile_Click(object sender, EventArgs e)
        {
            //string res;
            //tool.CompileCode(out res);
            //if (res != "")
            //{
            //    richTextBox_Res.AppendText("------------编译失败----------------");
            //    richTextBox_Res.AppendText(res);
            //}
            //else
            //    richTextBox_Res.AppendText("------------编译成功----------------");
        }

        private void button_Action_Click(object sender, EventArgs e)
        {
            //string res;
            //tool.RunOnce(out res);
            //if (res != "")
            //{
            //    richTextBox_Res.AppendText("------------执行失败----------------");
            //    richTextBox_Res.AppendText(res);
            //}
            //else
            //    richTextBox_Res.AppendText("------------执行成功----------------");
        }
    }
}
