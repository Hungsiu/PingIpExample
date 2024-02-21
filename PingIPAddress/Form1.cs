using System.Net.NetworkInformation;
using System.Net;
using System.Windows.Forms;
using System.Diagnostics;

namespace PingIPAddress
{
    public partial class Form1 : Form
    {
        private string Status
        {
            set
            {
                BeginInvoke(() => { labelStatus.Text = value; });
            }
        }

        private Dictionary<string, string> ResultList = new Dictionary<string, string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridViewResult.Columns.Add("IPColumn", "IP");
            dataGridViewResult.Columns.Add("ResultColumn", "Result");

            Status = "初始化完畢";
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridViewResult.Rows.Clear();

                var baseAddress = textBoxBaseAddress.Text + ".";
                var mini = int.Parse(textBoxMinAddress.Text);
                var maxi = int.Parse(textBoxMaxAddress.Text);

                Status = "搜尋中...";

                Stopwatch sw = new Stopwatch();
                sw.Start();
                for (int i = mini; i <= maxi; i++)
                {
                    var ip = baseAddress + i.ToString();
                    Debug.WriteLine("Current IP is " + ip);

                    bool success = PingHost(ip);
                    string result = success ? "有裝置使用" : "沒有裝置使用";

                    ResultList.Add(ip, result);
                }
                sw.Stop();

                GridViewUpdate();

                Status = "搜尋完畢,已使用 " + sw.ElapsedMilliseconds + "毫秒"; ;
            }
            catch (Exception ex)
            {
                Status = ex.Message;
            }
        }

        private bool PingHost(string address, int timeout = 10)
        {
            try
            {
                Ping ping = new Ping();
                PingReply reply = ping.Send(IPAddress.Parse(address), timeout);
                return reply.Status == IPStatus.Success;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void GridViewUpdate()
        {
            dataGridViewResult.Rows.Clear();

            foreach (var result in ResultList)
            {
                var success = result.Value == "有裝置使用";
                var rowIndex = dataGridViewResult.Rows.Add(result.Key, result.Value);

                if (success)
                {
                    dataGridViewResult.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                }
            }
        }
    }
}
