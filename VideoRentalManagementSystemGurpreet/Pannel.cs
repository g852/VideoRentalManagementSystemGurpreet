using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoRentalManagementSystemGurpreet
{
    public partial class Pannel : Form
    {
        DataManagement relObject = new DataManagement();
        String sql = "";
        int rId =0,vid=0,cid=0,RntId=0;
        public Pannel()
        {
            InitializeComponent();
        }

        private void VideoAdd_Click(object sender, EventArgs e)

        {
            //this record is used to insert the details of the video in the database table with the help of insert statement 
            if (TitleTxt.Text.Equals("") && RattingTxt.Text.Equals("") && PlotTxt.Text.Equals("") && GenreTxt.Text.Equals("") && Convert.ToInt32(YearNm.Value) > 0 && Convert.ToInt32(CopiesNm.Value) > 0 && Convert.ToInt32(CostNm.Value) > 0)
            {
                MessageBox.Show("Fill all the details of the video so the record can  be stored in the database table");
            }
            else {
                sql = "insert into videoData(title,ratting,year,copies,cost,plot,genre) values('"+ TitleTxt.Text+"','"+RattingTxt.Text+"','"+YearNm.Value.ToString()+"','"+CopiesNm.Value.ToString()+"','"+CostNm.Value.ToString()+"','"+PlotTxt.Text+"','"+GenreTxt.Text+"')";
                relObject.record(sql);
                MessageBox.Show("Record is stored in the Table");
            }
            clearAll();
        }

        private void VideoDelete_Click(object sender, EventArgs e)
        {
            //this record is used to delete the details of the video in the database table with the help of delete statement 
            if (MovieIDTxt.Text.Equals(""))
            {
                MessageBox.Show("Select the record from the video table to delete the record ");
            }
            else {
                sql = "";
                sql = "";
                if (relObject.count(Convert.ToInt32(MovieIDTxt.Text.ToString()), "rentData", "MovieId") > 0)
                {
                    MessageBox.Show("Video is already Booked so cannot delete now");
                }
                else
                {
                    sql = "delete from videoData where id=" + Convert.ToInt32(MovieIDTxt.Text.ToString()) + "";
                    relObject.record(sql);
                    MessageBox.Show("Record of the video is deleted from the table ");
                }
            }
            clearAll();
        }

        private void CustomerAdd_Click(object sender, EventArgs e)
        {
            //this record is used to record the details of the customer in the database table with the help of insert statement 
            if (CustomerFNameTxt.Text.Equals("") && CustomerLNameTxt.Text.Equals("") && CustomerMobileNm.Value > 0 && CustomerAddressTxt.Text.Equals(""))
            {
                MessageBox.Show("Fill all the details of the customer to register in the panel and save his detaild in the  database table ");
            }
            else {
                sql = "";
                sql = "insert into customerData(firstname,lastname,phone,address) values('"+CustomerFNameTxt.Text+"','"+CustomerLNameTxt.Text+"','"+CustomerMobileNm.Value.ToString()+"','"+CustomerAddressTxt.Text+"')";
                relObject.record(sql);
                MessageBox.Show("Record is saved in the customer table ");

            }
            clearAll();
        }

        private void Customer_Delete_Click(object sender, EventArgs e)
        {
            //this record is used to delete the details of the customer in the database table with the help of delete statement 
            if (CustomerIDTxt.Text.Equals(""))
            {
                MessageBox.Show("Select the details from the customer to delete the details of the customer");
            }
            else {

                if (relObject.count(Convert.ToInt32(CustomerIDTxt.Text.ToString()), "rentData", "customerId") > 0)
                {
                    MessageBox.Show("Customer is already have a video on rent he must have to return first then we can delete him");
                }
                else
                {




                    sql = "";
                    sql = "delete from customerData where id=" + Convert.ToInt32(CustomerIDTxt.Text.ToString()) + "";
                    relObject.record(sql);
                    MessageBox.Show("Record is deleted from the customer table");
                }
                clearAll();
            }
        }

        private void VideoUpdate_Click(object sender, EventArgs e)
        {
            //this record is used to update the details of the video in the database table with the help of update statement 
            if (TitleTxt.Text.Equals("") && RattingTxt.Text.Equals("") && MovieIDTxt.Text.Equals("") && PlotTxt.Text.Equals("") && GenreTxt.Text.Equals("") && Convert.ToInt32(YearNm.Value) > 0 && Convert.ToInt32(CopiesNm.Value) > 0 && Convert.ToInt32(CostNm.Value) > 0)
            {
                MessageBox.Show("Fill all the details of the video so the record can  be Updated  in the database table");
            }
            else
            {
                sql = "update videoData set title='"+ TitleTxt.Text + "',ratting='" + RattingTxt.Text + "',year='" + YearNm.Value.ToString() + "',copies='" + CopiesNm.Value.ToString() + "',cost='" + CostNm.Value.ToString() + "',plot='" + PlotTxt.Text + "',genre='" + GenreTxt.Text + "' where id="+Convert.ToInt32(MovieIDTxt.Text.ToString())+"";
                relObject.record(sql);
                MessageBox.Show("Record is Updated in the Table");
            }

            clearAll();
        }

        private void CustomerUpdate_Click(object sender, EventArgs e)
        {
            //this record is used to record the details of the customer in the database table with the help of insert statement 
            if (CustomerFNameTxt.Text.Equals("") && CustomerIDTxt.Text.Equals("") && CustomerLNameTxt.Text.Equals("") && CustomerMobileNm.Value > 0 && CustomerAddressTxt.Text.Equals(""))
            {
                MessageBox.Show("Fill all the details of the customer to register in the panel and save his detaild in the  database table ");
            }
            else
            {
                sql = "";
                sql = "update customerData set firstname='" + CustomerFNameTxt.Text + "',lastname='" + CustomerLNameTxt.Text + "',phone='" + CustomerMobileNm.Value.ToString() + "',address='" + CustomerAddressTxt.Text + "' where id="+Convert.ToInt32(CustomerIDTxt.Text.ToString())+"";
                relObject.record(sql);
                MessageBox.Show("Record is Updated in the customer table ");

            }
            clearAll();
        }

        private void BookVideo_Click(object sender, EventArgs e)
        {
            //this record is used to insert the details of the rental video in the database table with the help of insert statement 
            if (CustomerIDTxt.Text.Equals("") && MovieIDTxt.Text.Equals(""))
            {
                MessageBox.Show("select  the details then you can book an video for rent ");
            }
            else {
                // count the total no of videos booked by  the customer 
                int customerVideo = relObject.count(Convert.ToInt32(CustomerIDTxt.Text.ToString()), "rentData", "customerId");

                // count how many video caste are already booked 
                int VideoCnt = relObject.count(Convert.ToInt32(MovieIDTxt.Text.ToString()), "rentData", "MovieId");

                sql = "";
                sql = "select * from videoData where id="+Convert.ToInt32(MovieIDTxt.Text.ToString())+"";
                DataTable tbl = new DataTable();
                tbl = relObject.getRecord(sql);
                int copies =Convert.ToInt32(tbl.Rows[0]["copies"].ToString());
                if (customerVideo >= 2)
                {
                    MessageBox.Show("You already have 2 video's on rent so you cannot get any more");
                }
                else if (VideoCnt >= copies)
                {
                    MessageBox.Show("All video's are booked already ");
                }
                else
                {
                    sql = "";
                    sql = "insert into rentData(customerId,movieId,dateofIssue,dateofReturn) values('" + CustomerIDTxt.Text + "','" + MovieIDTxt.Text + "','" + IssueDateDtp.Text + "','Book')";
                    relObject.record(sql);
                    MessageBox.Show("Video is issed on Rent to the Register Customer ");
                }
                
            }
            clearAll();
        }

        private void customeretails_Click(object sender, EventArgs e)
        {
            
            cid = 1;
            sql = "";
            sql = "select * from customerData ";
            DataTable tbl = new DataTable();
            tbl = relObject.getRecord(sql);
            details.DataSource = tbl;

            vid = 0;
            RntId = 0;

        }

        private void RentalDetails_Click(object sender, EventArgs e)
        {
            
            RntId = 1;
            sql = "";
            sql = "select * from rentData ";
            DataTable tbl = new DataTable();
            tbl = relObject.getRecord(sql);
            details.DataSource = tbl;

            vid = 0;
            cid = 0;
        }

        private void CopiesNm_ValueChanged(object sender, EventArgs e)
        {


            // when we add  the year of the video then the cost of the video will be display automatically
            try
            {
                DateTime date = DateTime.Now;

                int year = date.Year;

                int yr = year - Convert.ToInt32(YearNm.Value);
                //if the  difference is more then the 5 year then the charges will be 2 dollar other wise 5 dollar per day
                if (yr >= 5)
                {
                    CostNm.Value = 2;
                }
                else if (yr >= 0 && yr < 5)
                {
                    CostNm.Value = 5;
                }
            }
            catch (Exception ex)
            {

            }


        }
        //clear all the value from the text boxes 
        public void clearAll() {
            TitleTxt.Text = relObject.reset();
            RattingTxt.Text= relObject.reset();
            PlotTxt.Text= relObject.reset();
            GenreTxt.Text= relObject.reset();
            YearNm.Value = 0;
            CostNm.Value = 0;
            CopiesNm.Value = 0;

            CustomerFNameTxt.Text= relObject.reset();
            CustomerLNameTxt.Text= relObject.reset();
            CustomerAddressTxt.Text= relObject.reset();
            CustomerMobileNm.Value = 0;

            MovieIDTxt.Text= relObject.reset();
            CustomerIDTxt.Text= relObject.reset();




        }

        private void details_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (vid==1) {

                MovieIDTxt.Text= details.CurrentRow.Cells[0].Value.ToString();
                TitleTxt.Text = details.CurrentRow.Cells[1].Value.ToString();
                RattingTxt.Text= details.CurrentRow.Cells[2].Value.ToString();
                YearNm.Value = Convert.ToInt32(details.CurrentRow.Cells[3].Value.ToString());
                CopiesNm.Value=Convert.ToInt32(details.CurrentRow.Cells[4].Value.ToString());
                CostNm.Value= Convert.ToInt32(details.CurrentRow.Cells[5].Value.ToString());
                PlotTxt.Text= details.CurrentRow.Cells[6].Value.ToString();
                GenreTxt.Text= details.CurrentRow.Cells[7].Value.ToString();





                
            }
            else if (cid==1) {

                CustomerIDTxt.Text= details.CurrentRow.Cells[0].Value.ToString();
                CustomerFNameTxt.Text= details.CurrentRow.Cells[1].Value.ToString();
                CustomerLNameTxt.Text= details.CurrentRow.Cells[2].Value.ToString();
                CustomerMobileNm.Value= Convert.ToInt32(details.CurrentRow.Cells[3].Value.ToString());
                CustomerAddressTxt.Text= details.CurrentRow.Cells[4].Value.ToString();


                
            }
            else if (RntId==1) {
                rId = Convert.ToInt32(details.CurrentRow.Cells[0].Value.ToString());
                CustomerIDTxt.Text= details.CurrentRow.Cells[1].Value.ToString();
                MovieIDTxt.Text= details.CurrentRow.Cells[2].Value.ToString();
                IssueDateDtp.Text= details.CurrentRow.Cells[3].Value.ToString();


                
            }
            vid = 0;
            cid = 0;
            RntId = 0;


        }

        private void button1_Click(object sender, EventArgs e)
        {

            DataTable tblData = new DataTable();
            tblData = relObject.getRecord("select * from videoData ");
            int x = 0, y = 0, cunt = 0;
            String Title = "";
            for (x = 0; x < tblData.Rows.Count; x++)
            {
                DataTable tblData1 = new DataTable();
                tblData1 = relObject.getRecord("select count(*) from rentData where MovieId=" + Convert.ToInt32(tblData.Rows[x]["id"].ToString()) + "");

                if (tblData1.Rows.Count > cunt)
                {
                    Title = tblData.Rows[x]["title"].ToString();
                    cunt = tblData1.Rows.Count;
                }

            }

            MessageBox.Show(Title);
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable tblData = new DataTable();
            tblData = relObject.getRecord("select * from customerData ");
            int x = 0, y = 0, cunt = 0;
            String Name = "";
            for (x = 0; x < tblData.Rows.Count; x++)
            {
                DataTable tblData1 = new DataTable();
                tblData1 = relObject.getRecord("select count(*) from rentData where customerId=" + Convert.ToInt32(tblData.Rows[x]["id"].ToString()) + "");

                if (tblData1.Rows.Count > cunt)
                {
                    Name = tblData.Rows[x]["firstname"].ToString() + " " + tblData.Rows[x]["lastname"].ToString();
                    cunt = tblData1.Rows.Count;
                }
            }
            MessageBox.Show(Name);

        }

        private void DeleteBookVideo_Click(object sender, EventArgs e)
        {
            //this code is used to delete the details of the rental data which is insert bymistake 
            if (rId == 0)
            {
                MessageBox.Show("Select the rental record to delete from the database table ");
            }
            else {
                sql = "";
                sql = "delete from rentData where id="+rId+"";
                relObject.record(sql);
                MessageBox.Show("Rental video record is deleted from the database table ");
            }
            clearAll();
        }

        private void ReturnVideo_Click(object sender, EventArgs e)
        {
            //this record is used to return  the video to the paneland update the detail  in the database table with the help of update statement 
            if (CustomerIDTxt.Text.Equals("") && MovieIDTxt.Text.Equals(""))
            {
                MessageBox.Show("select  the details then you can book an video for rent ");
            }
            else
            {

                sql = "";
                sql = "select * from videoData where id=" + Convert.ToInt32(MovieIDTxt.Text.ToString()) + "";
                DataTable tbl = new DataTable();
                tbl = relObject.getRecord(sql);
                int charges = Convert.ToInt32(tbl.Rows[0]["cost"]);


                int totalcharges = relObject.charges(IssueDateDtp.Text,charges);


                sql = "";
                sql = "update rentData customerId'" + CustomerIDTxt.Text + "',movieId='" + MovieIDTxt.Text + "',dateofIssue='" + IssueDateDtp.Text + "',dateofReturn='"+ReturnDateDtp.Text.ToString()+"' where id="+Convert.ToInt32(rId)+"";
                relObject.record(sql);
                MessageBox.Show("rental video is return to the panel and your total charges are =$"+totalcharges);

            }
            clearAll();
        }

        private void VideoDetails_Click(object sender, EventArgs e)
        {
            vid = 1;
            sql = "";

            

            sql = "select * from videoData ";
            DataTable tbl = new DataTable();
            tbl=relObject.getRecord(sql);

            details.DataSource = tbl;
            cid = 0;
            RntId = 0;

        }
    }
}
