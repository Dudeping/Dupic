using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace picdowload
{
    public partial class Form1 : Form
    {
        private string destDir; //目标文件夹
        private Thread thread;
        public Form1()
        {
            InitializeComponent();
            btnStop.Enabled = false;
        }

        private void btnSelectDestDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if(dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtDsetDir.Text = dlg.SelectedPath;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            string keyword = txtKeyWords.Text;
            if(string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("请输入关键字再搜索！");
                return;
            }
            destDir = txtDsetDir.Text;
            if (string.IsNullOrEmpty(destDir))
            {
                MessageBox.Show("请先选择要到保存的文件夹！");
                return;
            }

            if (!destDir.EndsWith("\\"))
            {
                destDir += "\\";
            }

            txtLog.Text = "";
            //避免了阻塞主线程
            thread = new Thread(()=> {
                ProcessDownload(keyword);
            });
            thread.Start();

            btnStop.Enabled = true;
            btnStart.Enabled = false;
            progressBar.Value = 1;
        }

        private void DownloadPage(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                string json = reader.ReadToEnd();
                JObject objRoot = (JObject)JsonConvert.DeserializeObject(json);
                JArray imgs = (JArray)objRoot["imgs"];

                for (int i = 0; i < imgs.Count; i++)
                {
                    JObject img = (JObject)imgs[i];
                    string objUrl = (string)img["objURL"];
                    
                    try
                    {
                        DownloadImage(objUrl);//避免一个方法中的代码过于复杂
                    }
                    catch (Exception ex)
                    {
                        //子线程的代码中操作界面控件要使用BeginInvoke
                        if (txtLog.IsHandleCreated)
                        {
                            txtLog.BeginInvoke(new Action(() =>
                            {
                                txtLog.AppendText(ex.Message + Environment.NewLine);
                            }));
                        }
                    }
                }
            }
        }

        private void DownloadImage(string objURL)
        {
            string destFile = Path.Combine(destDir, Path.GetFileName(objURL));

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(objURL);
            request.Referer = "http://image.baidu.com";

            if (txtLog.IsHandleCreated)
            {
                txtLog.BeginInvoke(new Action(() =>
                {
                    txtLog.AppendText("正在下载" + objURL + Environment.NewLine);
                }));
            }
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        using (Stream stream = response.GetResponseStream())
                        using (Stream fsStream = new FileStream(destFile, FileMode.Create))
                        {
                            stream.CopyTo(fsStream);
                            if (txtLog.IsHandleCreated)
                            {
                                txtLog.BeginInvoke(new Action(() =>
                                {
                                    txtLog.AppendText("已保存到：" + destFile + Environment.NewLine + Environment.NewLine);
                                }));
                            }
                        }
                    }
                    else
                    {
                        if (txtLog.IsHandleCreated)
                        {
                            txtLog.BeginInvoke(new Action(() =>
                            {
                                txtLog.AppendText("下载" + objURL + "失败，错误码：" + response.GetHashCode() + Environment.NewLine);
                            }));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (txtLog.IsHandleCreated)
                {
                    txtLog.BeginInvoke(new Action(() =>
                    {
                        txtLog.AppendText(ex.Message + Environment.NewLine);
                    }));
                }
                //txtLog.AppendText("下载" + objURL + "失败!" + Environment.NewLine);
            }
        }

        private void ProcessDownload(string keyword)
        {
            int pageCount = (int)numPageCount.Value;
            for (int i = 0; i < pageCount; i++)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://image.baidu.com/search/avatarjson?tn=resultjsonavatarnew&ie=utf-8&word=" + Uri.EscapeDataString(keyword) + "&cg=girl&pn=" + (i + 1) * 30 + "&rn=30&itg=0&z=0&fr=&lm=-1&ic=0&s=0&st=-1&gsm=f000000000f0");

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        using (Stream stream = response.GetResponseStream())
                        {
                            try
                            {
                                DownloadPage(stream);
                            }
                            catch (Exception ex)
                            {
                                if(txtLog.IsHandleCreated)
                                {
                                    txtLog.BeginInvoke(new Action(() =>
                                    {
                                        txtLog.AppendText(ex.Message + Environment.NewLine);
                                    }));
                                }
                            }
                        }
                    }
                    else
                    {
                        if(txtLog.IsHandleCreated)
                        {
                            txtLog.BeginInvoke(new Action(() =>
                            {
                                txtLog.AppendText("获取第" + i + 1 + "页失败！服务器返回错误：" + response.StatusCode + Environment.NewLine);
                            }));
                        }
                    }
                }

                if(progressBar.IsHandleCreated)
                {
                    progressBar.BeginInvoke(new Action(() =>
                    {
                        progressBar.Value = (int)((float)i / pageCount * 100);
                    }));
                }
            }

            if(progressBar.IsHandleCreated)
            {
                progressBar.BeginInvoke(new Action(() =>
                {
                    btnStop.Enabled = false;
                    btnStart.Enabled = true;
                    progressBar.Value = 100;
                    MessageBox.Show("下载完成！", "成功");
                }));
            }
        }

        private void numPageCount_ValueChanged(object sender, EventArgs e)
        {
            if(numPageCount.Value < 1 || numPageCount.Value > 100)
            {
                MessageBox.Show("页数格式错误，值必须在1-100之间！", "错误");
                numPageCount.Value = 1;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            thread.Abort();
            MessageBox.Show("已停止！", "消息");
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }
    }
}
