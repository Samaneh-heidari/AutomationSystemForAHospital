using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PresentDr.DataSet;
using PresentDr.DataAccess;
using AxShockwaveFlashObjects;
using System.Drawing.Text;
//using Microsoft.DirectX.AudioVideoPlayback;


namespace PresentDr
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        dsDr dsDr = new dsDr();
        dsPresentDr dsPresentDr = new dsPresentDr();
        dsDoctor dsDoctor = new dsDoctor();
        dsDoctor dsAllDr = new dsDoctor();
        dsTemp dsTemp = new dsTemp();


        dsDrDay dsDrDay = new dsDrDay();

        public Guid id;

        private int Interval;

        DataTable dtSource;
        DataTable dtSourceTemp;



        //int defaulPageSize = 3;
        int defaulPageSize = 1;
        int defaultInterval = 5;
        int PageCount;
        int maxRec;
        int pageSize = 1;
        int currentPage;
        int recNo;
        /*
        private void Form1_Load(object sender, EventArgs e)
        {

            dtSource = FillDtSource();
            FillTextBoxes();



        }
        
        private DataTable FillDtSource()
        {
            dsDr dsDr = new DrDataAccess().GetAllDr();
            foreach (dsDr.DrRow drRow in dsDr.Dr)
            {
                dsDoctor.DoctorRow drr = dsDoctor.Doctor.NewDoctorRow();
                String allDaysAndHours = "";

                dsHour dsh = (new HourDataAccess().GetByCardNum(drRow.cardNum));
                foreach (dsHour.HourRow h in dsh.Hour)
                {
                    dsDay dsday = new DayDataAccess().GetDayByDayID(h.dayId);
                    allDaysAndHours += (dsday.Day[0]).days + " " + h.fromTime + "الی" + h.toTime + ",";
                }

                dsSpecialty.SpecialtyRow sr = (new SpecialtyDataAccess().GetSpecialtyByID(drRow.specialtyId)).Specialty[0];

                if (drRow.IsbiographyNull()) drr.biography = "";
                else drr.biography = drRow.biography;
                drr.cardNum = drRow.cardNum;
                drr.fName = drRow.fName;
                drr.lName = drRow.lName;
                drr.KINDVKH = drRow.KINDVKH;
                drr.shNP = drRow.shNP;
                drr.specialty = sr.specialty;

                drr.days = allDaysAndHours;

                if (drRow.IspicNull()) drRow.pic = "";
                else drr.pic = drRow.pic;
                if (drRow.IsenNameNull()) drr.enName = "";
                else drr.enName = drRow.enName;
                if (sr.IsenSpecialtyNull()) drr.enSpecialty = "";
                else drr.enSpecialty = sr.enSpecialty;
                dsDoctor.Doctor.AddDoctorRow(drr);
            }

            dtSource = dsDoctor.Doctor;

            return dtSource;
        }

        private void FillTextBoxes()
        {
            int row = currentPage * defaulPageSize;
            maxRec = dtSource.Rows.Count;
            PageCount = maxRec / defaulPageSize;
            if ((maxRec % defaulPageSize) > 0)
            {
                PageCount += 1;
            }

            pnl2.Visible = true;

            shNP.Text = dtSource.Rows[row][7].ToString();
            madrak.Text = dtSource.Rows[row][11].ToString();
            biog.Text = dtSource.Rows[row][6].ToString();
            ruzha.Text = dtSource.Rows[row][0].ToString();
            farsiName.Text = dtSource.Rows[row][4].ToString() + " " + dtSource.Rows[row][5].ToString();

            picb1.ImageLocation = dtSource.Rows[row][9].ToString();

            lbl_enName.Text = "";
            lbl_enSpec.Text = "";
            if (!dtSource.Rows[row][10].ToString().Equals(""))
            {

                lbl_enSpec.Text = dtSource.Rows[row][12].ToString();
                lbl_enName.Text = "Dr. " + dtSource.Rows[row][10].ToString();

            }
        }
        */
        private void Form1_Load(object sender, EventArgs e)
        {
            System.Drawing.Rectangle resolution = Screen.GetBounds(this);
            this.picB_propaganda.Location = new System.Drawing.Point(0, 0);
            this.picB_propaganda.Size = new System.Drawing.Size(resolution.Width, resolution.Height);

            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(0, 0);
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(resolution.Width, resolution.Height);

            this.axShockwaveFlash1.Location = new System.Drawing.Point(0, 0);
            this.axShockwaveFlash1.Size = new System.Drawing.Size(resolution.Width, resolution.Height);

            

            // Create a private font collection
            FontFamily[] ff;
            PrivateFontCollection pfc = new PrivateFontCollection();

            pfc.AddFontFile("C:\\Windows\\Fonts\\BYekan_0.ttf");
            ff = pfc.Families;
            int count = ff.Length;

            //Font yagutFont = new Font(ff[0].Name, 16, FontStyle.Regular);

            lbl7.Font = new System.Drawing.Font(ff[0].Name, 12, FontStyle.Regular);
            lbl4.Font = new System.Drawing.Font(ff[0].Name, 12, FontStyle.Regular);
            lbl3.Font = new System.Drawing.Font(ff[0].Name, 12, FontStyle.Regular);
            lbl8.Font = new System.Drawing.Font(ff[0].Name, 12, FontStyle.Regular);
            label1.Font = new System.Drawing.Font(ff[0].Name, 12, FontStyle.Regular);

            shNP.Font = new System.Drawing.Font(ff[0].Name, 12, FontStyle.Regular);
            farsiName.Font = new System.Drawing.Font(ff[0].Name, 12, FontStyle.Regular);
            biog.Font = new System.Drawing.Font(ff[0].Name, 12, FontStyle.Regular);
            madrak.Font = new System.Drawing.Font(ff[0].Name, 12, FontStyle.Regular);
            ruzha.Font = new System.Drawing.Font(ff[0].Name, 12, FontStyle.Regular);

            lbl_enName.Font = new System.Drawing.Font(ff[0].Name, 10, FontStyle.Regular);
            lbl_enSpec.Font = new System.Drawing.Font(ff[0].Name, 10, FontStyle.Regular);

            dtSource = FillDtSource();
            FillTextBoxes();
        }
        private DataTable FillDtSource()
        {
            dsDr dsDr = new DrDataAccess().GetAllDr();


            foreach (dsDr.DrRow drRow in dsDr.Dr)
            {
                dsDoctor.DoctorRow drr = dsDoctor.Doctor.NewDoctorRow();
                dsTemp.Temp_TableRow tempR = dsTemp.Temp_Table.NewTemp_TableRow();

                String allDaysAndHours = "";
                String fromTime = "";
                String tmp_fTime = "";
                String toTime = "";
                String tmp_tT = "";


                dsHour dsh = (new HourDataAccess().GetByCardNum(drRow.cardNum));
                foreach (dsHour.HourRow h in dsh.Hour)
                {
                    tmp_fTime = h.fromTime.ToString();
                    if (tmp_fTime.Length == 1 || tmp_fTime.Length == 2)
                        fromTime = tmp_fTime;
                    else if (tmp_fTime.Length == 3)
                        fromTime = tmp_fTime.Substring(0, 1) + ":" + tmp_fTime.Substring(1, 2);
                    else if (tmp_fTime.Length == 4)
                        fromTime = tmp_fTime.Substring(0, 2) + ":" + tmp_fTime.Substring(2, 2);

                    tmp_tT = h.toTime.ToString();
                    if (tmp_tT.Length == 1 || tmp_tT.Length == 2)
                        toTime = tmp_tT;
                    else if (tmp_tT.Length == 3)
                        toTime = tmp_tT.Substring(0, 1) + ":" + tmp_tT.Substring(1, 2);
                    else if (tmp_tT.Length == 4)
                        toTime = tmp_tT.Substring(0, 2) + ":" + tmp_tT.Substring(2, 2);

                    dsDay dsday = new DayDataAccess().GetDayByDayID(h.dayId);
                    allDaysAndHours += (dsday.Day[0]).days + " " + fromTime + "-" + toTime + ",";
                }
                if (allDaysAndHours.Length != 0)
                    allDaysAndHours = allDaysAndHours.Substring(0, allDaysAndHours.Length - 1);

                dsSpecialty.SpecialtyRow sr = (new SpecialtyDataAccess().GetSpecialtyByID(drRow.specialtyId)).Specialty[0];

                if (drRow.IsbiographyNull()) drr.biography = "";
                else drr.biography = drRow.biography;
                drr.cardNum = drRow.cardNum;
                drr.fName = drRow.fName;
                drr.lName = drRow.lName;
                drr.KINDVKH = drRow.KINDVKH;
                drr.shNP = drRow.shNP;
                drr.specialty = sr.specialty;

                //drr.days = allDaysAndHours;
                /// add in 25 May 2011 by samaneh.
                drr.days = "not valid";
                tempR.dr_id = drRow.cardNum;
                tempR.dayHour = allDaysAndHours;
                ///

                if (drRow.IspicNull()) drRow.pic = "";
                else drr.pic = drRow.pic;
                if (drRow.IsenNameNull()) drr.enName = "";
                else drr.enName = drRow.enName;
                if (sr.IsenSpecialtyNull()) drr.enSpecialty = "";
                else drr.enSpecialty = sr.enSpecialty;
                dsDoctor.Doctor.AddDoctorRow(drr);
                dsTemp.Temp_Table.AddTemp_TableRow(tempR);
            }

            dtSource = dsDoctor.Doctor;
            dtSourceTemp = dsTemp.Temp_Table;

            return dtSource;
        }

        private void FillTextBoxes()
        {
            int row = currentPage * defaulPageSize;
            maxRec = dtSource.Rows.Count;
            PageCount = maxRec / defaulPageSize;
            if ((maxRec % defaulPageSize) > 0)
            {
                PageCount += 1;
            }

            pnl2.Visible = true;

            int maxBiogLength = 80;

            shNP.Text = dtSource.Rows[row][7].ToString();
            /*string tmpShNp = dtSource.Rows[row][7].ToString();
            if (tmpShNp.Length < maxBiogLength)
                tmpShNp = new string(' ', maxBiogLength - tmpShNp.Length) + tmpShNp;
            shNP.Text = tmpShNp;
            */
            madrak.Text = dtSource.Rows[row][11].ToString();
            /*string tmpMadrak = dtSource.Rows[row][11].ToString();
            if (tmpMadrak.Length < maxBiogLength)
                tmpMadrak = new string(' ', maxBiogLength - tmpMadrak.Length) + tmpMadrak;
            madrak.Text = tmpMadrak;
            */

            //biog.Text = dtSource.Rows[row][6].ToString();
            string tempBiog = dtSource.Rows[row][6].ToString();
            int indexOfSpace = 0;
            if (tempBiog.Length > maxBiogLength)
            {
                biog.Text = "";
                int index = 0;
                for (int i = 0; i < tempBiog.Length / maxBiogLength + 1; i++)
                    if (biog.Text.Length < tempBiog.Length)
                    {
                        if (index + maxBiogLength - 5 < tempBiog.Length)
                        {
                            indexOfSpace = tempBiog.IndexOf(' ', index + maxBiogLength - 5);
                            if (indexOfSpace > 0)
                                biog.Text += tempBiog.Substring(index, (indexOfSpace - index)) + "\n";
                            else
                            {
                                biog.Text += tempBiog.Substring(index);
                                break;
                            }
                        }
                        else
                            biog.Text += tempBiog.Substring(index);
                        index = indexOfSpace;
                    }
                    else
                    {
                        biog.Text += new string(' ', maxBiogLength - (tempBiog.Length - index)) + tempBiog.Substring(index);
                    }
            }
            else
            {
                biog.Text = new string(' ', maxBiogLength - tempBiog.Length) + tempBiog;
            }

            //ruzha.Text = dtSource.Rows[row][0].ToString();
            ruzha.Text = dtSourceTemp.Rows[row][1].ToString();
            /*string tmpRuz = dtSource.Rows[row][0].ToString();
            if (tmpRuz.Length < maxBiogLength)
                tmpRuz = new string(' ', maxBiogLength - tmpRuz.Length) + tmpRuz;
            ruzha.Text = tmpRuz;
            */

            farsiName.Text = dtSource.Rows[row][4].ToString() + " " + dtSource.Rows[row][5].ToString();
            /*string tmpFN = dtSource.Rows[row][4].ToString() + " " + dtSource.Rows[row][5].ToString();
            if (tmpFN.Length < maxBiogLength)
                tmpFN = new string(' ', maxBiogLength - tmpFN.Length) + tmpFN;
            farsiName.Text = tmpFN;
            */

            //String serverLocation = "\\192.168.1.6\\e\\Doctor pics\\";
            picb1.ImageLocation = dtSource.Rows[row][9].ToString();



            lbl_enName.Text = "";
            lbl_enSpec.Text = "";
            if (!dtSource.Rows[row][10].ToString().Equals(""))
            {
                /*string tmpEnSpec = dtSource.Rows[row][12].ToString();
                if (tmpEnSpec.Length < maxBiogLength)
                    tmpEnSpec = new string(' ', maxBiogLength - tmpEnSpec.Length) + tmpEnSpec;
                lbl_enSpec.Text = tmpEnSpec;
                 */
                lbl_enSpec.Text = dtSource.Rows[row][12].ToString();

                /*string tmpEnN = "Dr. " + dtSource.Rows[row][10].ToString();
                if (tmpEnN.Length < maxBiogLength)
                    tmpEnN = new string(' ', maxBiogLength - tmpEnN.Length) + tmpEnN;
                lbl_enName.Text = tmpEnN;
                */
                lbl_enName.Text = "Dr. " + dtSource.Rows[row][10].ToString();

            }
        }


        private void t1_Tick(object sender, EventArgs e)
        {

            dtSource = FillDtSource();

        }

        private void t2_Tick(object sender, EventArgs e)
        {
            currentPage++;
            if (currentPage >= PageCount)
                currentPage = 0;

            FillTextBoxes();
        }

        private void lbl4_Click(object sender, EventArgs e)
        {

        }

        private void tb2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void tb3_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl5_Click(object sender, EventArgs e)
        {

        }

        private void pnl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbl3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        //private string flashPath;// = @"C:\Users\v-shunli\Desktop\1.swf";
        //Timer used to record the time and trace the playing process.
        //Timer timer_flashDuration = new Timer();
        //Record the last frame index.
        private int _lastFrame = -1;
        //The frame count of the movie.
        private int _frameCount = 0;
        //Recored the time when ths movie starts playing.
        DateTime _flashStartTime = DateTime.MinValue;

        /*private void FlashForm_Load(object sender, EventArgs e)
        {
            //Handle this event to get the frame count.
            axShockwaveFlash1.OnReadyStateChange += new AxShockwaveFlashObjects._IShockwaveFlashEvents_OnReadyStateChangeEventHandler(axShockwaveFlash1_OnReadyStateChange);
            //Load the movie
            axShockwaveFlash1.LoadMovie(0, _moviePath);
            axShockwaveFlash1.Loop = false;
            timer_flashDuration.Interval = 100;
            timer_flashDuration.Tick += new EventHandler(_timer_Tick);
            timer_flashDuration.Start();
            axShockwaveFlash1.Play();
            _movieStartTime = DateTime.Now;
        }
         */
        void axShockwaveFlash1_OnReadyStateChange(object sender, AxShockwaveFlashObjects._IShockwaveFlashEvents_OnReadyStateChangeEvent e)
        {
            //"state = 4" means the movie loading is finished.
            if (e.newState == 4 && _frameCount == 0)
            {
                //Get the frame count.
                _frameCount = axShockwaveFlash1.TotalFrames;
            }
        }
        void timer_flashDuration_Tick(object sender, EventArgs e)
        {
            if (_frameCount != 0)
            {
                if (_lastFrame == _frameCount - 1)
                {
                    //The frame is the last one. In other words, the movie playing finishes.
                    //Stop the timer.
                    TimeSpan time = DateTime.Now - _flashStartTime;
                    //Show the message.
                    //MessageBox.Show(string.Format("Playing stops. Movie Length: {0}s", time.Milliseconds / 1000.0));
                    timer_flashDuration.Stop();
                    axShockwaveFlash1.Visible = false;
                    axShockwaveFlash1.Stop();

                    //Get the movie playing time.
                    //this.flashTimer2.Tick += new System.EventHandler(this.flashTimer2_Tick);
                    flashTimer2.Interval = 1;
                    flashTimer2.Start();
                    flashTimer1.Stop();
                }
                else
                {
                    //Save the current frame index.
                    _lastFrame = axShockwaveFlash1.FrameNum;
                }
            }

        }



        private void flashTimer1_Tick(object sender, EventArgs e)
        {
            //string path = Path.GetFullPath(@"..\pic and flash");
            string path = Path.GetFullPath(Environment.CurrentDirectory + @"\pic and flash");
            String[] allPicsAndFlashes = Directory.GetFiles(path);
            Random random = new Random();
            int rand = random.Next(allPicsAndFlashes.Length);
            string selectedFile = allPicsAndFlashes[rand];
            int dotIndex = selectedFile.IndexOf('.');
            //int pathLength = selectedFile.Length;
            //string suffix = selectedFile.Substring(dotIndex, (pathLength - dotIndex));
            string suffix = selectedFile.Substring(dotIndex);

            if (suffix.Equals(".jpg"))
            {
                picB_propaganda.Visible = true;
                picB_propaganda.Load(selectedFile);

                /*//select a music to play with picture
                string musicPath = Path.GetFullPath(@"..\..\pic and flash\music");
                String[] allMusices = Directory.GetFiles(musicPath);
                Random rndMusic = new Random();
                int randMusic = rndMusic.Next(allMusices.Length);
                axWindowsMediaPlayer1.URL = allMusices[randMusic];
                axWindowsMediaPlayer1.Show();
                */
                flashTimer2.Interval = flashTimer2_defaultValue;
                flashTimer2.Start();

            }
            else if (suffix.Equals(".swf"))
            {

                //Load the movie
                axShockwaveFlash1.Visible = true;
                axShockwaveFlash1.LoadMovie(0, selectedFile);
                axShockwaveFlash1.Loop = false;
                //timer_flashDuration.Interval = 100;
                //timer_flashDuration.Tick += new EventHandler(timer_flashDuration_Tick);
                axShockwaveFlash1.Play();
                //Handle this event to get the frame count.
                //axShockwaveFlash1.OnReadyStateChange += new AxShockwaveFlashObjects._IShockwaveFlashEvents_OnReadyStateChangeEventHandler(axShockwaveFlash1_OnReadyStateChange);
                if (_frameCount == 0)
                {
                    //Get the frame count.
                    _frameCount = axShockwaveFlash1.TotalFrames;
                }
                if (_frameCount == 1)
                {
                    axShockwaveFlash1.Loop = true;
                    timer_flashDuration.Interval = timer_flashDuration_defaultValue;
                }
                _flashStartTime = DateTime.Now;
                timer_flashDuration.Start();

            }
            else if (suffix.Equals(".mp3") || suffix.Equals(".wmv") ||
                     suffix.Equals(".mpeg") || suffix.Equals(".DAT"))
            {
                axWindowsMediaPlayer1.Visible = true;
                //axWindowsMediaPlayer1.URL = @"C:\Users\Public\Videos\Sample Videos\Wildlife.wmv";
                axWindowsMediaPlayer1.URL = selectedFile;
                axWindowsMediaPlayer1.Ctlcontrols.play();

                timer_MovieDuration.Start();
            }

            t1.Stop();
            t2.Stop();
            //tb2.Visible = false;
            ruzha.Visible = false;
            shNP.Visible = false;
            farsiName.Visible = false;
            biog.Visible = false;
            madrak.Visible = false;
            pnl2.Visible = false;
            //tb4.Visible = false;

            lbl_enName.Visible = false;
            lbl_enSpec.Visible = false;
            picb1.Visible = false;
            //flashTimer2.Start();
            flashTimer1.Stop();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        double dur = 0.0;// = axWindowsMediaPlayer1.currentMedia.duration;
        double currentPosition = 0;
        private int flashTimer2_defaultValue = 5000;
        private int timer_flashDuration_defaultValue = 5000;
        private void timer_MovieDuration_Tick_1(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
                axWindowsMediaPlayer1.fullScreen = true;

            if (axWindowsMediaPlayer1.currentMedia != null)
            {
                flashTimer2.Interval = Convert.ToInt32(axWindowsMediaPlayer1.currentMedia.duration - axWindowsMediaPlayer1.Ctlcontrols.currentPosition) * 1000;
            }
            else
            {
                flashTimer2.Interval = flashTimer2_defaultValue;
            }

            timer_MovieDuration.Stop();
            flashTimer2.Start();
        }


        private void flashTimer2_Tick(object sender, EventArgs e)
        {

            axShockwaveFlash1.Visible = false;
            axWindowsMediaPlayer1.Visible = false;
            picB_propaganda.Visible = false;
            axWindowsMediaPlayer1.close();

            //axWindowsMediaPlayer1.Ctlcontrols.pause();
            currentPosition = axWindowsMediaPlayer1.Ctlcontrols.currentPosition;
            if (axWindowsMediaPlayer1.currentMedia != null)
                dur = axWindowsMediaPlayer1.currentMedia.duration;

            flashTimer1.Start();
            flashTimer2.Stop();

            t2.Start();
            t1.Start();
            //tb2.Visible = true;
            ruzha.Visible = true;
            shNP.Visible = true;
            farsiName.Visible = true;
            biog.Visible = true;
            madrak.Visible = true;
            pnl2.Visible = true;


            //tb4.Visible = true;
            lbl_enName.Visible = true;
            lbl_enSpec.Visible = true;

            picb1.Visible = true;
        }

        private void axShockwaveFlash1_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void shNP_Click(object sender, EventArgs e)
        {

        }

        private void axShockwaveFlash1_Enter_1(object sender, EventArgs e)
        {

        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void axWindowsMediaPlayer1_Enter_1(object sender, EventArgs e)
        {

        }

        private void ruzha_Click(object sender, EventArgs e)
        {

        }

        private void picB_propaganda_Click(object sender, EventArgs e)
        {

        }


    }
}
