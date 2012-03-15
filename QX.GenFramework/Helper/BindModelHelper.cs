using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.Misc;

namespace QX.GenFramework.Helper
{
    public class BindModelHelper
    {


        /// <summary>
        /// 绑定数据实体数据到指定控件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="controls"></param>
        public void BindModelToControl<T>(T obj, Control.ControlCollection controls)
        {

            if (obj != null)
            {
                PropertyDescriptorCollection p = TypeDescriptor.GetProperties(typeof(T));
                foreach (Control item in controls)
                {
                    try
                    {
                        if (item.GetType() == typeof(TextBox))
                        {
                            if (p[item.Name] != null && p[item.Name].GetValue(obj) != null)
                            {
                                item.Text = p[item.Name].GetValue(obj).ToString();
                            }
                        }
                        else if (item.GetType() == typeof(RichTextBox))
                        {
                            if (p[item.Name] != null && p[item.Name].GetValue(obj) != null)
                            {
                                item.Text = p[item.Name].GetValue(obj).ToString();
                            }
                        }
                        else if (item.GetType() == typeof(DateTimePicker))
                        {
                            string time = string.Empty;
                            if (p[item.Name] != null && p[item.Name].GetValue(obj) != null)
                            {
                                time = p[item.Name].GetValue(obj).ToString();
                            }
                            if (!string.IsNullOrEmpty(time) && !time.Contains("0001"))
                            {
                                DateTime tempTime = DateTime.Now;
                                if (DateTime.TryParse(time, out tempTime))
                                {
                                    ((DateTimePicker)item).Value = tempTime;
                                }
                            }
                        }
                        else if (item.GetType() == typeof(ComboBox))
                        {

                            ((ComboBox)item).SelectedValue = p[item.Name].GetValue(obj);
                        }
                        else if (item.GetType() == typeof(CheckBox))
                        {
                            if (p[item.Name] != null && p[item.Name].GetValue(obj) != null)
                            {
                                ((CheckBox)item).Checked = p[item.Name].GetValue(obj).ToString() == "1" ? true : false;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }
        }


        //public void BindEventToControl(Control.ControlCollection controls, EventHandler handler)
        //{
        //    foreach (Control item in controls)
        //    {
        //        if (item.GetType() == objType)
        //        {
        //            item.TextChanged += handler;

        //        }
        //    }
        //}

        /// <summary>
        /// 把指定控件值集合绑定到对应实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="controls"></param>
        /// <returns></returns>
        public T BindControlToModel<T>(T obj, Control.ControlCollection controls)
        {

            if (obj != null)
            {
                PropertyDescriptorCollection p = TypeDescriptor.GetProperties(typeof(T));
                foreach (Control item in controls)
                {
                    //if (!string.IsNullOrEmpty(item.Text))
                    //{
                    if (!item.Visible || (item.GetType() != typeof(TextBox) && item.GetType() != typeof(DateTimePicker)
                    && item.GetType() != typeof(ComboBox) && item.GetType() != typeof(CheckBox)))
                    {
                        continue;
                    }
                    if (item.GetType() == typeof(TextBox) && p[item.Name] != null)
                    {
                        if (p[item.Name].PropertyType == typeof(DateTime))
                        {
                            p[item.Name].SetValue(obj, DateTime.Parse(item.Text));
                        }
                        else if (p[item.Name].PropertyType == typeof(System.Int32) || p[item.Name].PropertyType == typeof(System.Int64) || p[item.Name].PropertyType == typeof(System.Int16))
                        {
                            p[item.Name].SetValue(obj, int.Parse(item.Text));
                        }
                        else if (p[item.Name].PropertyType == typeof(System.Decimal))
                        {
                            p[item.Name].SetValue(obj, Decimal.Parse(item.Text));
                        }
                        else
                        {
                            p[item.Name].SetValue(obj, item.Text);
                        }
                    }
                    else if (item.GetType() == typeof(DateTimePicker))
                    {
                        if (p[item.Name] != null)
                        {
                            if (p[item.Name].PropertyType == typeof(DateTime))
                            {
                                p[item.Name].SetValue(obj, DateTime.Parse(item.Text));
                            }
                        }
                    }
                    else if (item.GetType() == typeof(ComboBox))
                    {
                        if (p[item.Name] != null)
                        {
                            ComboBox cb = (ComboBox)item;
                            if (string.IsNullOrEmpty(cb.ValueMember))
                            {
                                p[item.Name].SetValue(obj, cb.SelectedItem);
                            }
                            else
                            {
                                p[item.Name].SetValue(obj, cb.SelectedValue);
                            }
                        }
                    }
                    else if (item.GetType() == typeof(CheckBox))
                    {
                        int val = ((CheckBox)item).Checked ? 1 : 0;
                        if (p[item.Name].PropertyType == typeof(int))
                        {
                            p[item.Name].SetValue(obj, val);
                        }
                    }
                    //}
                    //else
                    //{
                    //    //if (item.GetType()==typeof(CheckBox))
                    //    //{
                    //    //    int val = ((CheckBox)item).Checked ? 1 : 0;
                    //    //    p[item.Name].SetValue(obj, val);
                    //    //}
                    //}
                }
            }
            return obj;
        }


        /// <summary>
        /// 绑定数据实体数据到指定控件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="controls"></param>
        public void BindModelToControl<T>(T obj, Control.ControlCollection controls, string prefix)
        {

            if (obj != null)
            {
                PropertyDescriptorCollection p = TypeDescriptor.GetProperties(typeof(T));
                foreach (Control item in controls)
                {
                    try
                    {
                        string name = string.Empty;
                        if (string.IsNullOrEmpty(prefix))
                        {
                            name = item.Name;
                        }
                        else
                        {
                            name = item.Name.Replace(prefix, " ").Trim();
                        }

                        if (item.GetType() == typeof(UltraNumericEditor))
                        {
                            if (p[name] != null && p[name].GetValue(obj) != null)
                            {

                                UltraNumericEditor nEditor = (UltraNumericEditor)item;
                                nEditor.Value = p[name].GetValue(obj).ToString();
                            }
                        }
                        else if (item.GetType() == typeof(UltraTextEditor))
                        {
                            if (p[name] != null && p[name].GetValue(obj) != null)
                            {
                                UltraTextEditor nEditor = (UltraTextEditor)item;
                                nEditor.Value = p[name].GetValue(obj).ToString();
                            }
                            else
                            {
                                UltraTextEditor nEditor = (UltraTextEditor)item;
                                nEditor.Value = string.Empty;
                            }
                        }
                        else if (item.GetType() == typeof(UltraComboEditor))
                        {
                            if (p[name] != null && p[name].GetValue(obj) != null)
                            {
                                item.Text = p[name].GetValue(obj).ToString();
                            }
                        }
                        else if (item.GetType() == typeof(UltraDateTimeEditor))
                        {
                            if (p[name] != null && p[name].GetValue(obj) != null)
                            {
                                UltraDateTimeEditor time = (UltraDateTimeEditor)item;
                                time.Value = p[name].GetValue(obj).ToString();
                            } 
                        }
                        else if (item.GetType() == typeof(UltraCombo))
                        {
                            if (p[name] != null && p[name].GetValue(obj) != null)
                            {
                                item.Text = p[name].GetValue(obj).ToString();
                            }
                        }
                        else if (item.GetType() == typeof(TextBox))
                        {
                            if (p[name] != null && p[name].GetValue(obj) != null)
                            {
                                item.Text = p[name].GetValue(obj).ToString();
                            }
                        }
                        else if (item.GetType() == typeof(RichTextBox))
                        {
                            if (p[name] != null && p[name].GetValue(obj) != null)
                            {
                                item.Text = p[name].GetValue(obj).ToString();
                            }
                        }
                        else if (item.GetType() == typeof(UltraDateTimeEditor))
                        {
                            string time = string.Empty;
                            if (p[name] != null && p[name].GetValue(obj) != null)
                            {
                                time = p[name].GetValue(obj).ToString();
                            }
                            if (!string.IsNullOrEmpty(time) && !time.Contains("0001"))
                            {
                                DateTime tempTime = DateTime.Now;
                                if (DateTime.TryParse(time, out tempTime))
                                {
                                    ((DateTimePicker)item).Value = tempTime;
                                }
                            }
                        }
                        else if (item.GetType() == typeof(ComboBox))
                        {

                            ((ComboBox)item).SelectedValue = p[name].GetValue(obj);
                        }
                        else if (item.GetType() == typeof(CheckBox))
                        {
                            if (p[name] != null && p[name].GetValue(obj) != null)
                            {
                                ((CheckBox)item).Checked = p[name].GetValue(obj).ToString() == "1" ? true : false;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }
        }

        public void ClearControl<T>(T obj, Control.ControlCollection controls, string prefix)
        {

            if (obj != null)
            {
                PropertyDescriptorCollection p = TypeDescriptor.GetProperties(typeof(T));
                foreach (Control item in controls)
                {
                    try
                    {
                        string name = string.Empty;
                        if (string.IsNullOrEmpty(prefix))
                        {
                            name = item.Name;
                        }
                        else
                        {
                            name = item.Name.Replace(prefix, " ").Trim();
                        }

                        if (item.GetType() == typeof(UltraNumericEditor))
                        {
                            if (p[name] != null)
                            {

                                UltraNumericEditor nEditor = (UltraNumericEditor)item;
                                nEditor.Value = 0;
                            }
                        }
                        else if (item.GetType() == typeof(UltraTextEditor))
                        {
                            if (p[name] != null )
                            {
                                UltraTextEditor nEditor = (UltraTextEditor)item;
                                nEditor.Value = null;
                            }
                        }
                        else if (item.GetType() == typeof(UltraComboEditor))
                        {
                            if (p[name] != null)
                            {
                                UltraComboEditor combo = (UltraComboEditor)item;
                                combo.Text = string.Empty;
                                combo.Value = string.Empty;
                            }
                        }
                        else if (item.GetType() == typeof(UltraDateTimeEditor))
                        {
                            if (p[name] != null)
                            {
                                UltraDateTimeEditor time = (UltraDateTimeEditor)item;
                                time.Value = DateTime.Now ;
                            }
                        }
                        else if (item.GetType() == typeof(UltraCombo))
                        {
                            if (p[name] != null)
                            {
                                UltraCombo combo = (UltraCombo)item;
                                combo.Text = string.Empty;
                                combo.Value = string.Empty;
                            }
                        }
                        else if (item.GetType() == typeof(TextBox))
                        {
                            if (p[name] != null)
                            {
                                item.Text = string.Empty;
                            }
                        }
                        else if (item.GetType() == typeof(RichTextBox))
                        {
                            if (p[name] != null)
                            {
                                item.Text =string.Empty;
                            }
                        }
                        else if (item.GetType() == typeof(UltraDateTimeEditor))
                        {
                            string time = string.Empty;
                            if (p[name] != null)
                            {
                                time = DateTime.Now.ToString();
                            }
                            if (!string.IsNullOrEmpty(time) && !time.Contains("0001"))
                            {
                                DateTime tempTime = DateTime.Now;
                                if (DateTime.TryParse(time, out tempTime))
                                {
                                    ((DateTimePicker)item).Value = tempTime;
                                }
                            }
                        }
                        else if (item.GetType() == typeof(ComboBox))
                        {

                            ((ComboBox)item).SelectedValue = p[name].GetValue(obj);
                        }
                        else if (item.GetType() == typeof(CheckBox))
                        {
                            if (p[name] != null && p[name].GetValue(obj) != null)
                            {
                                ((CheckBox)item).Checked = p[name].GetValue(obj).ToString() == "1" ? true : false;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }
        }

        public void BindEventToControl(Control.ControlCollection controls, Type objType, EventHandler handler)
        {
            foreach (Control item in controls)
            {
                if (item.GetType() == objType)
                {
                    item.TextChanged += handler;

                }
            }
        }

        /// <summary>
        /// 设置文本框是否可编辑
        /// </summary>
        /// <param name="flag"></param>
        public void DisableEditMode(System.Windows.Forms.Control.ControlCollection controls)
        {

            foreach (Control item in controls)
            {
                //if (item.GetType() != typeof(Label) || item.GetType().ToString() != "Infragistics.Win.Misc.UltraLabel")
                //{
                item.Enabled = false;
                //}
                //if (item.GetType() == typeof(UltraTextEditor))
                //{

                //    ((UltraTextEditor)item).ReadOnly = false;

                //}
                //else if (item.GetType() == typeof(Button))
                //{
                //    ((Button)item).Visible = true;
                //}
            }

        }

        //public void BindEventToControl(Control.ControlCollection controls, EventHandler handler)
        //{
        //    foreach (Control item in controls)
        //    {
        //        if (item.GetType() == objType)
        //        {
        //            item.TextChanged += handler;

        //        }
        //    }
        //}

        /// <summary>
        /// 把指定控件值集合绑定到对应实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="controls"></param>
        /// <returns></returns>
        public T BindControlToModel<T>(T obj, Control.ControlCollection controls, string prefix)
        {

            if (obj != null)
            {
                PropertyDescriptorCollection p = TypeDescriptor.GetProperties(typeof(T));
                foreach (Control item in controls)
                {
                    //if (!string.IsNullOrEmpty(item.Text))
                    //{
                        string name = string.Empty;
                        if (string.IsNullOrEmpty(prefix))
                        {
                            name = item.Name;
                        }
                        else
                        {
                            name = item.Name.Replace(prefix, " ").Trim();
                        }


                        if (p[name] != null)
                        {
                            if (p[name].PropertyType == typeof(DateTime))
                            {
                              
                                if (item.GetType() == typeof(UltraDateTimeEditor))
                                {
                                    UltraDateTimeEditor time=(UltraDateTimeEditor)item;
                                    if (time.Value != null)
                                    {
                                        p[name].SetValue(obj, DateTime.Parse(time.Value.ToString()));
                                    }

                                }
                                else
                                {
                                    if (!string.IsNullOrEmpty(item.Text))
                                    {
                                        p[name].SetValue(obj, DateTime.Parse(item.Text));
                                    }
                                    else
                                    {
                                        p[name].SetValue(obj,DateTime.Now);
                                    }
                                }
                            }
                            else if (p[name].PropertyType == typeof(System.Int32) || p[name].PropertyType == typeof(System.Int64) || p[name].PropertyType == typeof(System.Int16))
                            {
                                 
                                if (item.GetType() == typeof(UltraNumericEditor))
                                {

                                    UltraNumericEditor nEditor = (UltraNumericEditor)item;
                                    if (!string.IsNullOrEmpty(item.Text))
                                    {

                                        p[name].SetValue(obj, int.Parse(nEditor.Value.ToString()));
                                    }
                                    else
                                    {
                                        p[name].SetValue(obj, 0);
                                    }
                                    
                                }
                                else
                                {
                                    if (!string.IsNullOrEmpty(item.Text))
                                    {
                                        p[name].SetValue(obj, int.Parse(item.Text));
                                    }
                                    else
                                    {
                                        p[name].SetValue(obj, 0);
                                    }
                                }
                            }
                            else if (p[name].PropertyType == typeof(System.Decimal))
                            {
                                if (item.GetType() == typeof(UltraNumericEditor))
                                {
                                    if (!string.IsNullOrEmpty(item.Text))
                                    {

                                        UltraNumericEditor nEditor = (UltraNumericEditor)item;
                                        p[name].SetValue(obj, Decimal.Parse(nEditor.Value.ToString()));
                                    }
                                    else
                                    {
                                        UltraNumericEditor nEditor = (UltraNumericEditor)item;
                                        p[name].SetValue(obj, 0);
                                    }
                                }
                                else
                                {
                                    p[name].SetValue(obj, Decimal.Parse(item.Text));
                                }
                            }
                            else
                            {
                                if (item.GetType() == typeof(UltraCombo))
                                {
                                    UltraCombo uCombo = (UltraCombo)item;


                                    p[name].SetValue(obj, Convert.ChangeType(uCombo.Value, p[name].PropertyType));


                                }
                                else if (item.GetType() == typeof(UltraComboEditor))
                                {
                                    UltraComboEditor uCombo = (UltraComboEditor)item;
                                    p[name].SetValue(obj, uCombo.Value);
                                }
                                else
                                {
                                    p[name].SetValue(obj, item.Text);
                                }
                            }
                        }
                    //}
                    //    else if (item.GetType() == typeof(DateTimePicker))
                    //    {
                    //        if (p[name] != null)
                    //        {
                    //            if (p[name].PropertyType == typeof(DateTime))
                    //            {
                    //                p[name].SetValue(obj, DateTime.Parse(item.Text));
                    //            }
                    //        }
                    //    }
                    //    else if (item.GetType() == typeof(ComboBox))
                    //    {
                    //        if (p[name] != null)
                    //        {
                    //            ComboBox cb = (ComboBox)item;
                    //            if (string.IsNullOrEmpty(cb.ValueMember))
                    //            {
                    //                p[name].SetValue(obj, cb.SelectedItem);
                    //            }
                    //            else
                    //            {
                    //                p[name].SetValue(obj, cb.SelectedValue);
                    //            }
                    //        }
                    //    }
                    //    else if (item.GetType() == typeof(CheckBox))
                    //    {
                    //        int val = ((CheckBox)item).Checked ? 1 : 0;
                    //        if (p[name].PropertyType == typeof(int))
                    //        {
                    //            p[name].SetValue(obj, val);
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    //    //if (item.GetType()==typeof(CheckBox))
                    //    //{
                    //    //    int val = ((CheckBox)item).Checked ? 1 : 0;
                    //    //    p[name].SetValue(obj, val);
                    //    //}
                    //}
                }
            }
            return obj;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">搜索的控件类型</typeparam>
        /// <param name="controls"></param>
        /// <param name="cKey"></param>
        /// <returns></returns>
        public T FindCtl<T>(Control.ControlCollection controls, string cKey) where T : class
        {

            T refScompCtl = controls[cKey] as T;

            return refScompCtl;
        }

    }
}
