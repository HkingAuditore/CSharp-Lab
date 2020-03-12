using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSharp.Controllers;

namespace WebSharp
{
    public partial class ShowArray : System.Web.UI.Page
    {
        private static WebSharp.Controllers.StructType _mode;
        private static StructShowController<string> _structShowController;
        private static StringBuilder _stringBuilder;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _mode = StructType.NormalArray;
                _structShowController = new StructShowController<string>(_mode);
                _stringBuilder = new StringBuilder();
                UpdateInfo(_mode.ToString() + "已创建！");
            }


            ShowPanel();


        }

        #region VIEW_CONTROLLER

        /// <summary>
        /// 更新信息栏
        /// </summary>
        /// <param name="message">新增消息</param>
        private void UpdateInfo(string message)
        {
            _stringBuilder.Append(message + "<br/>");
            Info.Text = _stringBuilder.ToString();
           
        }

        /// <summary>
        /// 更新界面
        /// </summary>
        private void ShowPanel()
        {
            switch (_mode)
            {
                case StructType.NormalArray:
                case StructType.Array:
                case StructType.ArrayList:
                case StructType.List:
                    AddElementDiv.Visible = true;
                    AddKeyValueDiv.Visible = false;
                    RemoveKeyDiv.Visible = false;
                    break;
                case StructType.Dictionary:
                case StructType.HashTable:
                    AddElementDiv.Visible = false;
                    AddKeyValueDiv.Visible = true;
                    RemoveKeyDiv.Visible = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        #endregion


        #region ADD

        protected void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                switch (_mode)
                {
                    case StructType.NormalArray:
                    case StructType.Array:
                    case StructType.ArrayList:
                    case StructType.List:
                        _structShowController.Add(AddElement.Text);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                UpdateInfo(AddElement.Text + "已加入"+_mode.ToString()+"！");
            }
            catch (Exception exception)
            {
                UpdateInfo(exception.Message);
            }

        }
        protected void AddKeyValueButton_Click(object sender, EventArgs e)
        {
            try
            {
                switch (_mode)
                {
                    case StructType.Dictionary:
                    case StructType.HashTable:
                        _structShowController.Add(AddKey.Text, AddValue.Text);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                UpdateInfo("["+AddKey.Text +":"+AddValue.Text+"]"+ "已加入" + _mode.ToString() + "！");

            }
            catch (Exception exception)
            {
                UpdateInfo(exception.Message);
            }
        }

        #endregion

        #region REMOVE

        protected void RemoveElementButton_Click(object sender, EventArgs e)
        {
            try
            {
                switch (_mode)
                {
                    case StructType.NormalArray:
                    case StructType.Array:
                    case StructType.ArrayList:
                    case StructType.List:
                        _structShowController.Remove(RemoveElement.Text);
                        break;
                    case StructType.Dictionary:
                    case StructType.HashTable:
                        _structShowController.Remove(RemoveElement.Text);
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();

                }
                UpdateInfo(RemoveElement.Text + "已删除出" + _mode.ToString() + "！");
            }
            catch (Exception exception)
            {
                UpdateInfo(exception.Message);
            }
        }

        protected void RemoveKeyButton_Click(object sender, EventArgs e)
        {
            try
            {
                switch (_mode)
                {
                    case StructType.Dictionary:
                    case StructType.HashTable:
                        _structShowController.RemoveKey(RemoveKey.Text);
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();

                }
                UpdateInfo("键"+RemoveKey.Text + "已删除出" + _mode.ToString() + "！");
            }
            catch (Exception exception)
            {
                UpdateInfo(exception.Message);
            }

        }

        #endregion

        #region SORT

        protected void SequenceSort_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateInfo("顺序：");
                switch (_mode)
                {
                    case StructType.NormalArray:
                    case StructType.Array:
                    case StructType.ArrayList:
                    case StructType.List:
                        _structShowController.SequenceSort();
                        PrintInfo();
                        break;
                    case StructType.Dictionary:
                    case StructType.HashTable:
                        _structShowController.SequenceSortKey();
                        PrintInfo();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            catch (Exception exception)
            {
                UpdateInfo(exception.Message);
                throw;
            }
        }

        protected void ReverseSort_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateInfo("逆序：");
                switch (_mode)
                {
                    case StructType.NormalArray:
                    case StructType.Array:
                    case StructType.ArrayList:
                    case StructType.List:
                        _structShowController.ReverseSort();
                        PrintInfo();
                        break;
                    case StructType.Dictionary:
                    case StructType.HashTable:
                        _structShowController.ReverseSortKey();
                        PrintInfo();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            catch (Exception exception)
            {
                UpdateInfo(exception.Message);
                throw;
            }

        }


        #endregion



        #region PRINT

        private void PrintInfo()
        {
            switch (_mode)
            {
                case StructType.NormalArray:
                    for (var i = 0; i < _structShowController.NormalArray.Length; i++)
                    {
                        var item = _structShowController.NormalArray[i];
                        UpdateInfo("[" + i + "]" + item);
                    }

                    break;
                case StructType.Array:
                    for (var i = 0; i < _structShowController.ArrayInstance.Length; i++)
                    {
                        var item = _structShowController.ArrayInstance.GetValue(i);
                        UpdateInfo("[" + i + "]" + item);
                    }

                    break;
                case StructType.ArrayList:
                    int k = 0;
                    foreach (var item in _structShowController.ArrayListInstance)
                    {
                        UpdateInfo("[" + k + "]" + item);
                        k++;
                    }

                    break;
                case StructType.List:
                    int o = 0;
                    foreach (var item in _structShowController.ListInstance)
                    {
                        UpdateInfo("[" + o + "]" + item);
                        o++;
                    }

                    break;
                case StructType.Dictionary:
                    int p = 0;
                    foreach (var item in _structShowController.DictionaryInstance)
                    {
                        UpdateInfo("[" + p + "]" +item.Key+":"+ item.Value);
                        p++;
                    }

                    break;
                case StructType.HashTable:
                    int q = 0;
                    ICollection keys= _structShowController.HashTableInstance.Keys;
                    foreach (var key in keys)
                    {
                        UpdateInfo("[" +q+ "]"  +(string)key + ":" + (string)_structShowController.HashTableInstance[key] );
                        q++;
                    }

                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        

        #endregion

        #region STRUCT_TYPE_CHOICE

        protected void NormalArray_Click(object sender, EventArgs e)
        {
            _mode = StructType.NormalArray;
            _structShowController = new StructShowController<string>(_mode);
            _stringBuilder.Clear();
            UpdateInfo(_mode.ToString() + "已创建！");
            ShowPanel();

        }

        protected void Array_Click(object sender, EventArgs e)
        {
            _mode = StructType.Array;
            _structShowController = new StructShowController<string>(_mode);
            _stringBuilder.Clear();
            UpdateInfo(_mode.ToString() + "已创建！");
            ShowPanel();



        }

        protected void ArrayList_Click(object sender, EventArgs e)
        {
            _mode = StructType.ArrayList;
            _structShowController = new StructShowController<string>(_mode);
            _stringBuilder.Clear();
            UpdateInfo(_mode.ToString() + "已创建！");
            ShowPanel();



        }

        protected void List_Click(object sender, EventArgs e)
        {
            _mode = StructType.List;
            _structShowController = new StructShowController<string>(_mode);
            _stringBuilder.Clear();
            UpdateInfo(_mode.ToString() + "已创建！");
            ShowPanel();


        }

        protected void Dictionary_Click(object sender, EventArgs e)
        {
            _mode = StructType.Dictionary;
            _structShowController = new StructShowController<string>(_mode);
            _stringBuilder.Clear();
            UpdateInfo(_mode.ToString() + "已创建！");
            ShowPanel();


        }

        protected void HashTable_Click(object sender, EventArgs e)
        {
            _mode = StructType.HashTable;
            _structShowController = new StructShowController<string>(_mode);
            _stringBuilder.Clear();
            UpdateInfo(_mode.ToString() + "已创建！");
            ShowPanel();

        }


        #endregion

    }
}