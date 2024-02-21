using System.Net.NetworkInformation;
using System.Net;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.Concurrent;

namespace PingIPAddress
{
    public partial class Form1 : Form
    {
        private string Status
        {
            set
            {
                Invoke(() => { labelStatus.Text = value; });
            }
        }

        private ConcurrentDictionary<string, string> ResultList = new ConcurrentDictionary<string, string>();

        public Form1()
        {
            InitializeComponent();
            MaximizeBox = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridViewResult.Columns.Add("IPColumn", "IP");
            dataGridViewResult.Columns.Add("ResultColumn", "Result");

            Status = "��l�Ƨ���";
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridViewResult.Rows.Clear();

                var baseAddress = textBoxBaseAddress.Text + ".";
                var mini = int.Parse(textBoxMinAddress.Text);
                var maxi = int.Parse(textBoxMaxAddress.Text);

                Status = "�j�M��...";

                Stopwatch sw = new Stopwatch();
                sw.Start();


                var tasks = new List<Task>();
                for (int i = mini; i <= maxi; i++)
                {
                    var ip = baseAddress + i.ToString();
                    //Debug.WriteLine("Current IP is " + ip);

                    tasks.Add(Task.Run(() =>
                    {
                        bool success = PingHost(ip);
                        string result = success ? "���˸m�ϥ�" : "�S���˸m�ϥ�";

                        ResultList.TryAdd(ip, result);
                    }));
                }

                Status = "��ƾ�z��...";

                // ���ݩҦ����ȧ���
                Task.WaitAll(tasks.ToArray());

                sw.Stop();

                GridViewUpdate(ResultList.OrderBy(p => p.Value).ToDictionary<string,string>());

                Status = "�j�M����,�w�ϥ� " + sw.ElapsedMilliseconds + "�@��"; ;
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

        private void GridViewUpdate(Dictionary<string,string> list)
        {
            dataGridViewResult.Rows.Clear();

            foreach (var result in list)
            {
                var success = result.Value == "���˸m�ϥ�";
                var rowIndex = dataGridViewResult.Rows.Add(result.Key, result.Value);

                if (success)
                {
                    dataGridViewResult.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                }
            }

        }

        private void buttonSearch2_Click(object sender, EventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();

            Parallel.For(1, 255,
                index =>
                {
                    var ip = "192.168.1." + index;
                    PingHost(ip);
                });

            sw.Stop();
            Debug.WriteLine(sw.ElapsedMilliseconds + " ms");
        }
    }
}
