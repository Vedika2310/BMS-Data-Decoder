using System.IO;
using System.Linq;


namespace BMS_Data_Decoder
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            dataGridView1.Visible = false;
            // --- Button Style ---
            btnLoad.FlatStyle = FlatStyle.Flat;
            btnLoad.FlatAppearance.BorderSize = 0;
            btnLoad.BackColor = Color.FromArgb(100, 149, 237); // light blue
            btnLoad.ForeColor = Color.White;
            btnLoad.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnLoad.Cursor = Cursors.Hand;

            // hover effect
            btnLoad.MouseEnter += (s, e) => { btnLoad.BackColor = Color.FromArgb(65, 105, 225); }; // darker blue
            btnLoad.MouseLeave += (s, e) => { btnLoad.BackColor = Color.FromArgb(100, 149, 237); };
            // --- Form Style ---
            this.BackColor = Color.White;          // light background
            this.ForeColor = Color.FromArgb(30, 30, 30); // dark text
            this.Font = new Font("Segoe UI", 10);


            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ForeColor = Color.FromArgb(30, 30, 30);
            dataGridView1.GridColor = Color.FromArgb(200, 200, 200); // light gray grid
            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.DefaultCellStyle.ForeColor = Color.FromArgb(30, 30, 30);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240); // light header
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(30, 30, 30);
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dataGridView1.Width = 1200;
            dataGridView1.Height = 600;

            dataGridView1.RowTemplate.Height = 35;
            dataGridView1.Font = new Font("Segoe UI", 11);

            // alternate row color
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250); // very light gray



            Label lblTitle = new Label();
            lblTitle.Text = "BMS Data Decoder";
            lblTitle.Font = new Font("Segoe UI", 15, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(30, 30, 30);
            lblTitle.Dock = DockStyle.Top;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(lblTitle);

            Panel topPanel = new Panel();
            topPanel.Height = 80;
            topPanel.Dock = DockStyle.Top;
            topPanel.BackColor = Color.FromArgb(245, 245, 245); // very light gray
            this.Controls.Add(topPanel);
            topPanel.Controls.Add(lblTitle);
            topPanel.Controls.Add(btnLoad);
            btnLoad.Location = new Point(20, 20);
            // move toward center // adjust position




        }

        ushort ReadUInt16BigEndian(byte[] data, ref int offset)
        {
            ushort value = (ushort)((data[offset] << 8) | data[offset + 1]);
            offset += 2;
            return value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV Files (*.csv)|*.csv";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                byte[] fileBytes = File.ReadAllBytes(ofd.FileName);

                /* FIND HEADER END */
                int headerEnd = Array.IndexOf(fileBytes, (byte)'<');

                /* REMOVE HEADER BYTES */
                byte[] dataBytes = fileBytes.Skip(headerEnd).ToArray();
                List<BMSFrame> frames = new List<BMSFrame>();
                int offset = 0;

                while (offset < dataBytes.Length)
                {
                    // find start marker <+
                    int start = Array.IndexOf(dataBytes, (byte)'<', offset);
                    if (start < 0 || start + 1 >= dataBytes.Length) break;

                    if (dataBytes[start + 1] != (byte)'+')
                    {
                        offset = start + 1; // skip invalid '<'
                        continue;
                    }

                    int frameStart = start + 2; // skip <+

                    // check if enough bytes for frame + end marker
                    if (frameStart + 95 + 2 > dataBytes.Length) break;

                    int frameEnd = 0;

<<<<<<< HEAD
                    for(int i = frameStart; i < dataBytes.Length - 1; i++)
=======
                    for (int i = frameStart; i < dataBytes.Length - 1; i++)
>>>>>>> eb060a4 (Added new BMS parameters to decoder)
                    {
                        if (dataBytes[i] == (byte)'\r' && dataBytes[i + 1] == (byte)'\n')
                        {
                            frameEnd = i - 1;
                            break;
                        }
                    }

                    byte[] frameBytes = dataBytes.Skip(frameStart).Take(frameEnd - frameStart + 1).ToArray();

                    // check end marker \n\r
                    //if (dataBytes[frameStart + 95] != (byte)'\r' || dataBytes[frameStart + 95 + 1] != (byte)'\n')
                    //{
                    //    offset = frameStart + 1; // skip invalid frame
                    //    continue;
                    //}

                    // decode frameBytes exactly like before
<<<<<<< HEAD
                    
                    BMSFrame frame = new BMSFrame();
                    offset = frameStart;

                    frame.BAT_Voltage = BitConverter.ToUInt16(dataBytes, offset) * 10;
                    offset += 2;

                    frame.Capacity = BitConverter.ToInt32(dataBytes, offset);
                    offset += 4;

                    frame.FaultBits = BitConverter.ToUInt32(dataBytes, offset);
                    offset += 4;

                    frame.AccumulatedSeconds = BitConverter.ToUInt32(dataBytes, offset);
                    offset += 4;

                    frame.RestartCounter = BitConverter.ToUInt16(dataBytes, offset);
                    offset += 2;

                    frame.PresentStateStatus = dataBytes[offset];
                    offset += 1;

                    frame.BAT_Current = BitConverter.ToInt16(dataBytes, offset);
                    offset += 2;

                    frame.MaxCellVoltage = BitConverter.ToUInt16(dataBytes, offset);
                    offset += 2;

                    frame.MinCellVoltage = BitConverter.ToUInt16(dataBytes, offset);
                    offset += 2;

                    frame.AverageCellVoltage = BitConverter.ToUInt16(dataBytes, offset);
                    offset += 2;

                    frame.CycleCount = BitConverter.ToUInt32(dataBytes, offset);
=======

                    BMSFrame frame = new BMSFrame();
                    offset = frameStart;


                    frame.stackVoltage = (BitConverter.ToInt16(dataBytes, offset) * 10);
                    offset += 2;

                    frame.batteryCapacity = BitConverter.ToInt32(dataBytes, offset);
                    offset += 4;

                    frame.faultBits = BitConverter.ToUInt32(dataBytes, offset);
                    offset += 4;

                    frame.BMS_Uptime = BitConverter.ToUInt32(dataBytes, offset);
>>>>>>> eb060a4 (Added new BMS parameters to decoder)
                    offset += 4;

                    frame.CC2_Current = BitConverter.ToInt32(dataBytes, offset);
                    offset += 4;

                    frame.cycleCount = BitConverter.ToUInt32(dataBytes, offset);
                    offset += 4;

                    frame.balanceFlag = BitConverter.ToUInt32(dataBytes, offset);
                    offset += 4;

                    frame.screenshotTimeStamp = BitConverter.ToUInt32(dataBytes, offset);
                    offset += 4;

                    frame.PACK_PinVoltage = BitConverter.ToInt16(dataBytes, offset);
                    offset += 2;

                    frame.client_id = BitConverter.ToUInt16(dataBytes, offset);
                    offset += 2;

<<<<<<< HEAD
                    frame.CHGFET_Status = dataBytes[offset];
                    offset += 1;
=======
                    frame.softwareUpdateVersion = BitConverter.ToUInt16(dataBytes, offset);
                    offset += 2;

                   
                    
                    frame.controller_TS1_Temp = BitConverter.ToInt16(dataBytes, offset); offset += 2;
                    frame.controller_TS2_Temp = BitConverter.ToInt16(dataBytes, offset); offset += 2;
                    frame.controller_TS3_Temp = BitConverter.ToInt16(dataBytes, offset); offset += 2;
                    frame.controller_TS4_Temp = BitConverter.ToInt16(dataBytes, offset); offset += 2;
                    frame.controller_TS5_Temp = BitConverter.ToInt16(dataBytes, offset); offset += 2;
                    frame.controller_TS6_Temp = BitConverter.ToInt16(dataBytes, offset); offset += 2;
>>>>>>> eb060a4 (Added new BMS parameters to decoder)

                    frame.BQ_InternalTemp = BitConverter.ToInt16(dataBytes, offset);
                    offset += 2;

<<<<<<< HEAD
=======
                    frame.BQ_TS3_Temp = BitConverter.ToInt16(dataBytes, offset);
                    offset += 2;

           

>>>>>>> eb060a4 (Added new BMS parameters to decoder)
                    frame.C1 = BitConverter.ToInt16(dataBytes, offset); offset += 2;
                    frame.C2 = BitConverter.ToInt16(dataBytes, offset); offset += 2;
                    frame.C3 = BitConverter.ToInt16(dataBytes, offset); offset += 2;
                    frame.C4 = BitConverter.ToInt16(dataBytes, offset); offset += 2;
                    frame.C5 = BitConverter.ToInt16(dataBytes, offset); offset += 2;
                    frame.C6 = BitConverter.ToInt16(dataBytes, offset); offset += 2;
                    frame.C7 = BitConverter.ToInt16(dataBytes, offset); offset += 2;
                    frame.C8 = BitConverter.ToInt16(dataBytes, offset); offset += 2;
                    frame.C9 = BitConverter.ToInt16(dataBytes, offset); offset += 2;
                    frame.C10 = BitConverter.ToInt16(dataBytes, offset); offset += 2;
                    frame.C11 = BitConverter.ToInt16(dataBytes, offset); offset += 2;
                    frame.C12 = BitConverter.ToInt16(dataBytes, offset); offset += 2;
                    frame.C13 = BitConverter.ToInt16(dataBytes, offset); offset += 2;
                    frame.C14 = BitConverter.ToInt16(dataBytes, offset); offset += 2;
                    frame.C15 = BitConverter.ToInt16(dataBytes, offset); offset += 2;
                    frame.C16 = BitConverter.ToInt16(dataBytes, offset); offset += 2;

                    frame.configModifyCount = dataBytes[offset];
                    offset += 1;

                    frame.minorRevision = dataBytes[offset];
                    offset += 1;

                    frame.projectSeries = dataBytes[offset];
                    offset += 1;

                    frame.SOC_ChargePercentage = dataBytes[offset];
                    offset += 1;

                    frame.SOH = dataBytes[offset];
                    offset += 1;

                    frame.StatusBits = dataBytes[offset];
                    offset += 1;

                    frame.fileNumber = dataBytes[offset];
                    offset += 1;

                   
                    

                    frames.Add(frame);
                    // move offset to next frame
                    offset += 2; // skip \n\r
                }

                dataGridView1.Visible = true;   // show table

                dataGridView1.Columns.Clear();
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = frames;
                MessageBox.Show($"Loaded {frames.Count} frames successfully!");
            }

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV Files (*.csv)|*.csv";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string[] lines = File.ReadAllLines(ofd.FileName);

                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();

                dataGridView1.Columns.Add("RawData", "Encoded CSV Data");

                foreach (string line in lines)
                {
                    dataGridView1.Rows.Add(line);
                }

                dataGridView1.Visible = true;   // show table after loading file
            }
        }
    }
}
public class BMSFrame
{
<<<<<<< HEAD
    public uint AccumulatedSeconds { get; set; }
    public ushort RestartCounter { get; set; }
    public byte PresentStateStatus { get; set; }
    public int BAT_Voltage { get; set; }
    public short BAT_Current { get; set; }
    public ushort MaxCellVoltage { get; set; }
    public ushort MinCellVoltage { get; set; }
    public ushort AverageCellVoltage { get; set; }
    public int Capacity { get; set; }
    public uint CycleCount { get; set; }
    public uint BalanceFlag { get; set; }
=======
   
    
    public int stackVoltage { get; set; }
    public int batteryCapacity { get; set; }
    public uint faultBits { get; set; }
    public uint BMS_Uptime { get; set; }
    public int CC2_Current { get; set; }
    public uint cycleCount { get; set; }
    public uint balanceFlag { get; set; }
    public uint screenshotTimeStamp { get; set; }
    public short PACK_PinVoltage { get; set; }
    public ushort client_id { get; set; }
    public ushort softwareUpdateVersion { get; set; }
>>>>>>> eb060a4 (Added new BMS parameters to decoder)

  

    public short controller_TS1_Temp { get; set; }
    public short controller_TS2_Temp { get; set; }
    public short controller_TS3_Temp { get; set; }
    public short controller_TS4_Temp { get; set; }
    public short controller_TS5_Temp { get; set; }
    public short controller_TS6_Temp { get; set; }
    public short BQ_InternalTemp { get; set; }
    public short BQ_TS3_Temp { get; set; }

    public short C1 { get; set; }
    public short C2 { get; set; }
    public short C3 { get; set; }
    public short C4 { get; set; }
    public short C5 { get; set; }
    public short C6 { get; set; }
    public short C7 { get; set; }
    public short C8 { get; set; }
    public short C9 { get; set; }
    public short C10 { get; set; }
    public short C11 { get; set; }
    public short C12 { get; set; }
    public short C13 { get; set; }
    public short C14 { get; set; }
    public short C15 { get; set; }
    public short C16 { get; set; }


    public byte configModifyCount { get; set; }


    public byte minorRevision { get; set; }
    public byte projectSeries { get; set; }
    public byte SOC_ChargePercentage { get; set; }
    public byte SOH { get; set; }
    public byte StatusBits { get; set; }
    public byte fileNumber { get; set; }

   

}