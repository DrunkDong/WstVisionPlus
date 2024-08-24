using WstCommonTools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace WstControls
{
    public static class ToolOP
    {
        public static ToolType GetTypeFromString(string name)
        {
            switch (name)
            {
                case "Image Convert":
                    return ToolType.TransImage;
                case "Image Threshold":
                    return ToolType.BlobImage;
                case "Image Matching":
                    return ToolType.ShapeModel;
                case "Find Line":
                    return ToolType.FindLine;
                case "Find Circle":
                    return ToolType.FindCircle;
                case "If":
                    return ToolType.If;
                case "Else":
                    return ToolType.Else;
                case "Camera":
                    return ToolType.Camera;
                default:
                    return ToolType.None;
            }
        }

        public static ToolBase GetToolFromType(ToolType type)
        {
            switch (type)
            {
                case ToolType.TransImage:
                    return new ImageConvertTool();
                case ToolType.BlobImage:
                    return new ImageBlobTool();
                case ToolType.ShapeModel:
                    return new ShapeModelTool();
                case ToolType.FindLine:
                    return new ImageFindLineTool();
                case ToolType.FindCircle:
                    return new ImageFindCircleTool();
                case ToolType.If:
                    return new IfTool();
                case ToolType.Else:
                    return new ElseTool();
                case ToolType.Camera:
                    return new CameraAcqTool();
                default:
                    return null;
            }
        }

        //序列化工具
        public static OperateStatus SerializableTool(ToolBase tool, out byte[] buff)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream serializationStream = new MemoryStream();
            buff = null;
            try
            {
                switch (tool.Type)
                {
                    case ToolType.TransImage:
                        formatter.Serialize(serializationStream, (ImageConvertTool)tool);
                        break;
                    case ToolType.BlobImage:
                        formatter.Serialize(serializationStream, (ImageBlobTool)tool);
                        break;
                    case ToolType.ShapeModel:
                        formatter.Serialize(serializationStream, (ShapeModelTool)tool);
                        break;
                    case ToolType.FindLine:
                        formatter.Serialize(serializationStream, (ImageFindLineTool)tool);
                        break;
                    case ToolType.FindCircle:
                        formatter.Serialize(serializationStream, (ImageFindCircleTool)tool);
                        break;
                    case ToolType.Camera:
                        formatter.Serialize(serializationStream, (CameraAcqTool)tool);
                        break;
                    case ToolType.If:
                        formatter.Serialize(serializationStream, (IfTool)tool);
                        break;
                    case ToolType.Else:
                        formatter.Serialize(serializationStream, (ElseTool)tool);
                        break;
                    default:
                        break;
                }

                long length = serializationStream.Length;
                buff = new byte[(length + 8L) + 4L];

                byte[] a = BitConverter.GetBytes((long)((length + 8L) + 4L));
                byte[] b = BitConverter.GetBytes((int)tool.Type);
                byte[] c = serializationStream.ToArray();

                Array.Copy(a, buff, 8L);
                Array.Copy(b, 0, buff, 8L, 4L);
                Array.Copy(c, 0, buff, 12L, length);
                return OperateStatus.OK;
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(ex.Message);
                return OperateStatus.Error;
            }
        }

        //反序列化工具
        public static OperateStatus DeserializableTool(byte[] buff, out ToolBase tool)
        {
            tool = null;
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                MemoryStream serializationStream = new MemoryStream();
                int num = BitConverter.ToInt32(buff, 0);
                serializationStream.Write(buff, 4, buff.Length - 4);
                serializationStream.Seek(0L, SeekOrigin.Begin);
                ToolType type = (ToolType)num;

                switch (type)
                {
                    case ToolType.TransImage:
                        tool = (ImageConvertTool)formatter.Deserialize(serializationStream);
                        break;
                    case ToolType.BlobImage:
                        tool = (ImageBlobTool)formatter.Deserialize(serializationStream);
                        break;
                    case ToolType.ShapeModel:
                        tool = (ShapeModelTool)formatter.Deserialize(serializationStream);
                        break;
                    case ToolType.FindLine:
                        tool = (ImageFindLineTool)formatter.Deserialize(serializationStream);
                        break;
                    case ToolType.FindCircle:
                        tool = (ImageFindCircleTool)formatter.Deserialize(serializationStream);
                        break;
                    case ToolType.Camera:
                        tool = (CameraAcqTool)formatter.Deserialize(serializationStream);
                        break;
                    case ToolType.If:
                        tool = (IfTool)formatter.Deserialize(serializationStream);
                        break;
                    case ToolType.Else:
                        tool = (ElseTool)formatter.Deserialize(serializationStream);
                        break;
                    default:
                        break;
                }
                return OperateStatus.OK;
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(ex.Message);
                return OperateStatus.Error;
            }
        }

        //序列化工具列表
        public static OperateStatus SaveToolList(string filename, List<ToolBase> toolList)
        {
            FileStream fs = null;
            BinaryWriter bw = null;
            long datalength = 0;
            try
            {
                //读取本地文件
                fs = new FileStream(filename, FileMode.Create);
                bw = new BinaryWriter(fs);
                fs.Seek(sizeof(long), SeekOrigin.Begin);
                //将参数类打成byte[]
                foreach (ToolBase item in toolList)
                {
                    byte[] buff;
                    SerializableTool(item, out buff);
                    datalength += buff.Length;
                    bw.Write(buff, 0, buff.Length);
                }
                fs.Seek(0, SeekOrigin.Begin);
                bw.Write(BitConverter.GetBytes(datalength), 0, sizeof(long));
                bw.Close();
                fs.Close();
                return OperateStatus.OK;
            }
            catch (System.Exception ex)
            {
                if (bw != null)
                    bw.Close();
                if (fs != null)
                    fs.Close();
                LogHelper.WriteExceptionLog("SaveToolList;" + ex.Message);
                return OperateStatus.Error;
            }
        }

        //反序列化工具列表
        public static OperateStatus ReadToolList(string filename, out List<ToolBase> toolList)
        {
            toolList = new List<ToolBase>();
            FileStream fs1 = null;
            BinaryReader br = null;
            long lengthdata = 0;
            long lengthcurr = 0;
            try
            {

                fs1 = new FileStream(filename, FileMode.Open);
                br = new BinaryReader(fs1);
                byte[] buff1 = new byte[8];
                br.Read(buff1, 0, 8);
                lengthdata = BitConverter.ToInt64(buff1, 0);

                while (lengthdata > 0)
                {
                    lengthcurr = 0;
                    buff1 = new byte[8];
                    br.Read(buff1, 0, 8);
                    //获取对象字节长度
                    lengthcurr = BitConverter.ToInt64(buff1, 0);
                    buff1 = new byte[lengthcurr - sizeof(long)];
                    br.Read(buff1, 0, (int)(lengthcurr - sizeof(long)));
                    //生成工具参数对象
                    ToolBase tool;
                    DeserializableTool(buff1, out tool);
                    //添加工具
                    toolList.Add(tool);
                    lengthdata -= lengthcurr;
                }
                fs1.Close();
                br.Close();
                return OperateStatus.OK;

            }
            catch (System.Exception ex)
            {
                if (fs1 != null)
                    fs1.Close();
                if (br != null)
                    br.Close();
                LogHelper.WriteExceptionLog("ReadToolList;" + ex.Message);
                return OperateStatus.Error;
            }
        }

    }
}
