using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schematiseren
{
    public partial class Schematiseren : Form
    {
        List<Persoon> persoonLijst = new List<Persoon>();
        List<Datum> dataLijst = new List<Datum>();
        List<List<WDag>> NamenLijstDagDatumAutosHT = new List<List<WDag>>();
        int intAantalAutos = 0;
        int intMaxAantalPassagiers;
        public Schematiseren()
        {
            InitializeComponent();
            persoonLijst.Add(new Persoon()
            {
                Naam = "Lore",
                Dinsdag = 3,
                Woensdag = 3
            });
            persoonLijst.Add(new Persoon()
            {
                Naam = "Luna",
                Dinsdag = 3,
                Woensdag = 3
            });
            persoonLijst.Add(new Persoon()
            {
                Naam = "Janne",
                Dinsdag = 3,
                Woensdag = 3
            });
            persoonLijst.Add(new Persoon()
            {
                Naam = "Fleur",
                Dinsdag = 3,
                Woensdag = 3
            });
            persoonLijst.Add(new Persoon()
            {
                Naam = "Maurien",
                Dinsdag = 3,
                Woensdag = 4
            });
            ConvertPersonListToDL();
            cbCarsDIfferent.Checked = false;
            lblError.Text = string.Empty;
            List<cmbItem> cmbItemList = new List<cmbItem>();
            cmbItem newcmbItem = new cmbItem();
            newcmbItem.Text = "Heen";
            newcmbItem.Value = 1;
            cmbItemList.Add(newcmbItem);
            newcmbItem = new cmbItem();
            newcmbItem.Text = "Terug";
            newcmbItem.Value = 2;
            cmbItemList.Add(newcmbItem);
            newcmbItem = new cmbItem();
            newcmbItem.Text = "Heen & terug";
            newcmbItem.Value = 3;
            cmbItemList.Add(newcmbItem);
            cmbMaandag.Items.Clear();
            cmbDinsdag.Items.Clear();
            cmbWoensdag.Items.Clear();
            cmbDonderdag.Items.Clear();
            cmbVrijdag.Items.Clear();
            cmbZaterdag.Items.Clear();
            cmbZondag.Items.Clear();
            foreach (var person in persoonLijst){
                cmbNotCombineWith.Items.Add(person.Naam);
            }
            UpdateCheckBoxes();
            foreach (cmbItem acmbItem in cmbItemList)
            {
                cmbMaandag.Items.Add(acmbItem);
                cmbDinsdag.Items.Add(acmbItem);
                cmbWoensdag.Items.Add(acmbItem);
                cmbDonderdag.Items.Add(acmbItem);
                cmbVrijdag.Items.Add(acmbItem);
                cmbZaterdag.Items.Add(acmbItem);
                cmbZondag.Items.Add(acmbItem);
            }
            lblCMaandag.Text = string.Empty;
            lblCDinsdag.Text = string.Empty;
            lblCWoensdag.Text = string.Empty;
            lblCDonderdag.Text = string.Empty;
            lblCVrijdag.Text = string.Empty;
            lblCZaterdag.Text = string.Empty;
            lblCZondag.Text = string.Empty;
            cmbMixen.SelectedIndex = 0;
            dateTimePicker1.Value = DateTime.Now.AddDays(6);
            dateTimePicker2.Value = new DateTime(DateTime.Now.Year+1, 5, 31);
            btnAddSpecific_Click(null, null);
            dataLijst.RemoveAll(x => DateTime.Parse(x.Date) >= new DateTime(DateTime.Now.Year, 10, 28) && DateTime.Parse(x.Date) <= new DateTime(DateTime.Now.Year, 11, 5));
            dataLijst.RemoveAll(x => DateTime.Parse(x.Date) >= new DateTime(DateTime.Now.Year, 12, 1) && DateTime.Parse(x.Date) <= new DateTime(DateTime.Now.Year+1, 1, 7));
            dataLijst.RemoveAll(x => DateTime.Parse(x.Date) >= new DateTime(DateTime.Now.Year+1, 2, 10) && DateTime.Parse(x.Date) <= new DateTime(DateTime.Now.Year+1, 2, 18));
            dataLijst.RemoveAll(x => DateTime.Parse(x.Date) >= new DateTime(DateTime.Now.Year+1, 3, 30) && DateTime.Parse(x.Date) <= new DateTime(DateTime.Now.Year+1, 4, 14));
            ConvertDataListToDLData();

            //Controleer of het de eerste keer is of deze applicatie gebruikt wordt op deze pc
            string strCD = Environment.CurrentDirectory + "\\Schematiseren.txt";
            if (!File.Exists(strCD))
            {
                string strIP = string.Empty;
                if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                {
                    var host = Dns.GetHostEntry(Dns.GetHostName());
                    foreach (var ip in host.AddressList)
                    {
                        if (ip.AddressFamily == AddressFamily.InterNetwork)
                        {
                            strIP = ip.ToString();
                        }
                    }
                    string strMail = "thimo.mortelmans@gmail.com";
                    string strDomein = Environment.UserDomainName;
                    string strNaam = Environment.UserName;
                    string strCurrentDirectory = Environment.CurrentDirectory;
                    if (strNaam == null || strNaam == string.Empty)
                    {
                        strNaam = "iemand";
                    }
                    string strBody = "Hallo Thimo," + Environment.NewLine + Environment.NewLine;
                    strBody += "Zojuist heeft " + strNaam + " de applicatie 'Schematiseren' geïnstalleerd op zijn/haar pc: " + Environment.MachineName.ToString() + Environment.NewLine;
                    strBody += "Het IP adres van deze pc is: " + strIP + Environment.NewLine;
                    strBody += "In domein: " + strDomein + Environment.NewLine;
                    strBody += "Folderpad: " + strCurrentDirectory + Environment.NewLine + Environment.NewLine;
                    strBody += "Mvg," + Environment.NewLine + "Schematiseren installatiedetector";

                    SmtpClient client = new SmtpClient();
                    MailMessage msg = new MailMessage();
                    try
                    {
                        //setup SMTP Host Here
                        client.Host = "smtp.gmail.com";
                        client.UseDefaultCredentials = false;
                        client.EnableSsl = true;
                        client.Port = 587;
                        System.Net.NetworkCredential smtpCreds = new System.Net.NetworkCredential(strMail, "FMGR4ph18w!");
                        client.Credentials = smtpCreds;

                        //convert strings to MailAdresses
                        MailAddress to = new MailAddress(strMail);
                        MailAddress from = new MailAddress(strMail);

                        //set up message settings
                        msg.Subject = "Schematiseren installatie";
                        msg.Body = strBody;
                        msg.From = from;
                        msg.To.Add(to);
                        msg.IsBodyHtml = false;

                        //Send mail
                        client.Send(msg);
                        //MessageBox.Show(strBody);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    File.WriteAllText(strCD, "Do not delete this file.");
                }
            }

            #region commentaarlijnen
            ////Voeg tijdelijk vaste waarden toe om te testen
            //Persoon aPersoon = new Persoon();
            //aPersoon.Naam = "Janne";
            //aPersoon.Maandag = 1;
            //aPersoon.Woensdag = 3;
            //persoonLijst.Add(aPersoon);
            //Persoon bPersoon = new Persoon();
            //bPersoon.Naam = "Fleur";
            //bPersoon.Maandag = 2;
            //bPersoon.Woensdag = 3;
            //persoonLijst.Add(bPersoon);
            //Persoon cPersoon = new Persoon();
            //cPersoon.Naam = "Luna";
            //cPersoon.Maandag = 3;
            //cPersoon.Woensdag = 3;
            //persoonLijst.Add(cPersoon);
            //Persoon dPersoon = new Persoon();
            //dPersoon.Naam = "Lore";
            //dPersoon.Maandag = 3;
            //dPersoon.Woensdag = 1;
            //persoonLijst.Add(dPersoon);
            //Persoon ePersoon = new Persoon();
            //ePersoon.Naam = "Maurien";
            //ePersoon.Maandag = 3;
            //ePersoon.Woensdag = 1;
            //persoonLijst.Add(ePersoon);
            //Persoon fPersoon = new Persoon();
            //fPersoon.Naam = "Aurelie";
            //fPersoon.Maandag = 3;
            //fPersoon.Woensdag = 2;
            //persoonLijst.Add(fPersoon);
            //Persoon gPersoon = new Persoon();
            //gPersoon.Naam = "Fee";
            //gPersoon.Maandag = 3;
            //gPersoon.Woensdag = 2;
            //persoonLijst.Add(gPersoon);
            //Persoon hPersoon = new Persoon();
            //hPersoon.Naam = "Roos";
            //hPersoon.Maandag = 1;
            //hPersoon.Woensdag = 3;
            //persoonLijst.Add(hPersoon);
            //Persoon iPersoon = new Persoon();
            //iPersoon.Naam = "Sofie";
            //iPersoon.Maandag = 2;
            //iPersoon.Woensdag = 3;
            //persoonLijst.Add(iPersoon);
            //Persoon jPersoon = new Persoon();
            //jPersoon.Naam = "Kate";
            //jPersoon.Maandag = 3;
            //jPersoon.Woensdag = 1;
            //persoonLijst.Add(jPersoon);
            //Persoon kPersoon = new Persoon();
            //kPersoon.Naam = "Lotte";
            //kPersoon.Maandag = 3;
            //kPersoon.Woensdag = 2;
            //persoonLijst.Add(kPersoon);
            //Persoon lPersoon = new Persoon();
            //lPersoon.Naam = "Ann";
            //lPersoon.Maandag = 2;
            //lPersoon.Woensdag = 3;
            //persoonLijst.Add(lPersoon);
            //Persoon mPersoon = new Persoon();
            //mPersoon.Naam = "Amelie";
            //mPersoon.Maandag = 2;
            //mPersoon.Woensdag = 3;
            //persoonLijst.Add(mPersoon);
            //ConvertPersonListToDL();

            //Datum aDate = new Datum();
            //DateTime aDateTime = new DateTime();
            ////Maandagen
            //aDateTime = new DateTime(2020, 8, 31);
            //aDate.Date = aDateTime.Day.ToString() + "/" + aDateTime.Month.ToString() + "/" + aDateTime.Year.ToString();
            //aDate.Weekdag = "Maandag";
            //dataLijst.Add(aDate);
            //for (int intcounter = 0; intcounter < 43; intcounter++)
            //{
            //    aDateTime = aDateTime.AddDays(7);
            //    Datum bDate = new Datum();
            //    bDate.Weekdag = aDate.Weekdag;
            //    bDate.Date = aDateTime.Day.ToString() + "/" + aDateTime.Month.ToString() + "/" + aDateTime.Year.ToString();
            //    DateTime xDateTime = new DateTime(2020, 11, 2);
            //    if (aDateTime != xDateTime)
            //    {
            //        xDateTime = new DateTime(2020, 12, 21);
            //        if (aDateTime.Date != xDateTime)
            //        {
            //            xDateTime = new DateTime(2020, 12, 28);
            //            if (aDateTime != xDateTime)
            //            {
            //                xDateTime = new DateTime(2021, 2, 15);
            //                if (aDateTime != xDateTime)
            //                {
            //                    xDateTime = new DateTime(2021, 4, 5);
            //                    if (aDateTime != xDateTime)
            //                    {
            //                        xDateTime = new DateTime(2021, 4, 12);
            //                        if (aDateTime != xDateTime)
            //                        {
            //                            xDateTime = new DateTime(2021, 5, 24);
            //                            if (aDateTime != xDateTime)
            //                            {
            //                                dataLijst.Add(bDate);
            //                            }
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
            //////Woensdagen
            //aDateTime = new DateTime(2020, 9, 2);
            //aDate.Date = aDateTime.Day.ToString() + "/" + aDateTime.Month.ToString() + "/" + aDateTime.Year.ToString();
            //aDate.Weekdag = "Woensdag";
            //for (int intcounter = 0; intcounter < 43; intcounter++)
            //{
            //    aDateTime = aDateTime.AddDays(7);
            //    Datum bDate = new Datum();
            //    bDate.Weekdag = aDate.Weekdag;
            //    bDate.Date = aDateTime.Day.ToString() + "/" + aDateTime.Month.ToString() + "/" + aDateTime.Year.ToString();
            //    DateTime xDateTime = new DateTime(2020, 11, 4);
            //    if (aDateTime != xDateTime)
            //    {
            //        xDateTime = new DateTime(2020, 12, 23);
            //        if (aDateTime.Date != xDateTime)
            //        {
            //            xDateTime = new DateTime(2020, 12, 30);
            //            if (aDateTime != xDateTime)
            //            {
            //                xDateTime = new DateTime(2021, 2, 17);
            //                if (aDateTime != xDateTime)
            //                {
            //                    xDateTime = new DateTime(2021, 4, 7);
            //                    if (aDateTime != xDateTime)
            //                    {
            //                        xDateTime = new DateTime(2021, 4, 14);
            //                        if (aDateTime != xDateTime)
            //                        {
            //                            dataLijst.Add(bDate);
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}

            //ConvertDataListToDLData();

            //cmbAantalAutos.Text = "2";

            //cmbMaxPassagiers.Text = "2";

            //cbMaandag.Checked = true;
            //cbWoensdag.Checked = true;

            //cbShortMaand.Checked = true;
            #endregion

        }
        private void UpdateCheckBoxes()
        {
            foreach (var persoon in persoonLijst){
                if (!cbMaandag.Checked && persoon.Maandag != 0){
                    cbMaandag.Checked = true;
                }
                if (!cbDinsdag.Checked && persoon.Dinsdag != 0){
                    cbDinsdag.Checked = true;
                }
                if (!cbWoensdag.Checked && persoon.Woensdag != 0){
                    cbWoensdag.Checked = true;
                }
                if (!cbDonderdag.Checked && persoon.Donderdag != 0){
                    cbDonderdag.Checked = true;
                }
                if (!cbVrijdag.Checked && persoon.Vrijdag != 0){
                    cbVrijdag.Checked = true;
                }
                if (!cbZaterdag.Checked && persoon.Zaterdag != 0){
                    cbZaterdag.Checked = true;
                }
                if (!cbZondag.Checked && persoon.Zondag != 0){
                    cbZondag.Checked = true;
                }
            }
        }
        #region pnlPersonen
        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            if (txtName.Text != string.Empty)
            {
                bool NaamBestaat = false;
                foreach (Persoon aPerson in persoonLijst)
                {
                    if (aPerson.Naam == txtName.Text)
                    {
                        NaamBestaat = true;
                        break;
                    }
                }
                if (!NaamBestaat)
                {
                    lblError.Text = string.Empty;
                    Persoon newPerson = new Persoon();
                    newPerson.Naam = txtName.Text;
                    if (cmbMaandag.SelectedItem != null)
                    {
                        newPerson.Maandag = Convert.ToInt32((cmbMaandag.SelectedItem as cmbItem).Value);
                    }
                    else
                    {
                        newPerson.Maandag = 0;
                    }
                    if (cmbDinsdag.SelectedItem != null)
                    {
                        newPerson.Dinsdag = Convert.ToInt32((cmbDinsdag.SelectedItem as cmbItem).Value);
                    }
                    else
                    {
                        newPerson.Dinsdag = 0;
                    }
                    if (cmbWoensdag.SelectedItem != null)
                    {
                        newPerson.Woensdag = Convert.ToInt32((cmbWoensdag.SelectedItem as cmbItem).Value);
                    }
                    else
                    {
                        newPerson.Woensdag = 0;
                    }
                    if (cmbDonderdag.SelectedItem != null)
                    {
                        newPerson.Donderdag = Convert.ToInt32((cmbDonderdag.SelectedItem as cmbItem).Value);
                    }
                    else
                    {
                        newPerson.Donderdag = 0;
                    }
                    if (cmbVrijdag.SelectedItem != null)
                    {
                        newPerson.Vrijdag = Convert.ToInt32((cmbVrijdag.SelectedItem as cmbItem).Value);
                    }
                    else
                    {
                        newPerson.Vrijdag = 0;
                    }
                    if (cmbZaterdag.SelectedItem != null)
                    {
                        newPerson.Zaterdag = Convert.ToInt32((cmbZaterdag.SelectedItem as cmbItem).Value);
                    }
                    else
                    {
                        newPerson.Zaterdag = 0;
                    }
                    if (cmbZondag.SelectedItem != null)
                    {
                        newPerson.Zondag = Convert.ToInt32((cmbZondag.SelectedItem as cmbItem).Value);
                    }
                    else
                    {
                        newPerson.Zondag = 0;
                    }
                    cmbNotCombineWith.Items.Add(newPerson.Naam);
                    persoonLijst.Add(newPerson);
                    txtName.Text = string.Empty;
                    cmbMaandag.SelectedItem = null;
                    cmbDinsdag.SelectedItem = null;
                    cmbWoensdag.SelectedItem = null;
                    cmbDonderdag.SelectedItem = null;
                    cmbVrijdag.SelectedItem = null;
                    cmbZaterdag.SelectedItem = null;
                    cmbZondag.SelectedItem = null;
                    ConvertPersonListToDL();
                }
                else
                {
                    lblError.Text = "Deze naam is al in de lijst.";
                }
            }
            else
            {
                lblError.Text = "Vul een naam in.";
            }
        }
        private void ConvertPersonListToDL()
        {
            DL.Rows.Clear();
            if (persoonLijst != null)
            {
                if (persoonLijst.Count > 0)
                {
                    foreach (Persoon aPerson in persoonLijst)
                    {
                        int intRowNumber = DL.Rows.Add();
                        string strTemp = string.Empty;
                        DL.Rows[intRowNumber].Cells[0].Value = aPerson.Naam;
                        switch (aPerson.Maandag)
                        {
                            case 1:
                                strTemp = "Heen";
                                break;
                            case 2:
                                strTemp = "Terug";
                                break;
                            case 3:
                                strTemp = "Heen & terug";
                                break;
                            case 4:
                                strTemp = "Meerijden";
                                break;
                            default:
                                strTemp = string.Empty;
                                break;
                        }
                        DL.Rows[intRowNumber].Cells[1].Value = strTemp;
                        switch (aPerson.Dinsdag)
                        {
                            case 1:
                                strTemp = "Heen";
                                break;
                            case 2:
                                strTemp = "Terug";
                                break;
                            case 3:
                                strTemp = "Heen & terug";
                                break;
                            case 4:
                                strTemp = "Meerijden";
                                break;
                            default:
                                strTemp = string.Empty;
                                break;
                        }
                        DL.Rows[intRowNumber].Cells[2].Value = strTemp;
                        switch (aPerson.Woensdag)
                        {
                            case 1:
                                strTemp = "Heen";
                                break;
                            case 2:
                                strTemp = "Terug";
                                break;
                            case 3:
                                strTemp = "Heen & terug";
                                break;
                            case 4:
                                strTemp = "Meerijden";
                                break;
                            default:
                                strTemp = string.Empty;
                                break;
                        }
                        DL.Rows[intRowNumber].Cells[3].Value = strTemp;
                        switch (aPerson.Donderdag)
                        {
                            case 1:
                                strTemp = "Heen";
                                break;
                            case 2:
                                strTemp = "Terug";
                                break;
                            case 3:
                                strTemp = "Heen & terug";
                                break;
                            case 4:
                                strTemp = "Meerijden";
                                break;
                            default:
                                strTemp = string.Empty;
                                break;
                        }
                        DL.Rows[intRowNumber].Cells[4].Value = strTemp;
                        switch (aPerson.Vrijdag)
                        {
                            case 1:
                                strTemp = "Heen";
                                break;
                            case 2:
                                strTemp = "Terug";
                                break;
                            case 3:
                                strTemp = "Heen & terug";
                                break;
                            case 4:
                                strTemp = "Meerijden";
                                break;
                            default:
                                strTemp = string.Empty;
                                break;
                        }
                        DL.Rows[intRowNumber].Cells[5].Value = strTemp;
                        switch (aPerson.Zaterdag)
                        {
                            case 1:
                                strTemp = "Heen";
                                break;
                            case 2:
                                strTemp = "Terug";
                                break;
                            case 3:
                                strTemp = "Heen & terug";
                                break;
                            case 4:
                                strTemp = "Meerijden";
                                break;
                            default:
                                strTemp = string.Empty;
                                break;
                        }
                        DL.Rows[intRowNumber].Cells[6].Value = strTemp;
                        switch (aPerson.Zondag)
                        {
                            case 1:
                                strTemp = "Heen";
                                break;
                            case 2:
                                strTemp = "Terug";
                                break;
                            case 3:
                                strTemp = "Heen & terug";
                                break;
                            case 4:
                                strTemp = "Meerijden";
                                break;
                            default:
                                strTemp = string.Empty;
                                break;
                        }
                        DL.Rows[intRowNumber].Cells[7].Value = strTemp;
                    }
                }
            }
        }
        private void DL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblError.Text = string.Empty;
            if (DL.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.DL.SelectedRows[0];
                if ((DL.Rows.Count - 1) > row.Index)
                {
                    if (txtName.Text != row.Cells["Firstname"].Value.ToString())
                    { //Eerste keer geselecteerd
                        txtName.Enabled = false;
                        txtName.Text = row.Cells["Firstname"].Value.ToString();
                        cmbMaandag.SelectedIndex = cmbMaandag.FindStringExact(row.Cells["Monday"].Value.ToString());
                        cmbDinsdag.SelectedIndex = cmbDinsdag.FindStringExact(row.Cells["Tuesday"].Value.ToString());
                        cmbWoensdag.SelectedIndex = cmbWoensdag.FindStringExact(row.Cells["Wednesday"].Value.ToString());
                        cmbDonderdag.SelectedIndex = cmbDonderdag.FindStringExact(row.Cells["Thursday"].Value.ToString());
                        cmbVrijdag.SelectedIndex = cmbVrijdag.FindStringExact(row.Cells["Friday"].Value.ToString());
                        cmbZaterdag.SelectedIndex = cmbZaterdag.FindStringExact(row.Cells["Saterday"].Value.ToString());
                        cmbZondag.SelectedIndex = cmbZondag.FindStringExact(row.Cells["Sunday"].Value.ToString());
                        var value = row.Cells["NotCombineWith"].Value;
                        if (value != null){
                            cmbNotCombineWith.SelectedIndex = cmbZaterdag.FindStringExact(value.ToString());
                        }
                    }
                    else
                    { //Tweede keer geselecteerd
                        txtName.Enabled = true;
                        txtName.Text = string.Empty;
                        cmbMaandag.SelectedItem = null;
                        cmbDinsdag.SelectedItem = null;
                        cmbWoensdag.SelectedItem = null;
                        cmbDonderdag.SelectedItem = null;
                        cmbVrijdag.SelectedItem = null;
                        cmbZaterdag.SelectedItem = null;
                        cmbZondag.SelectedItem = null;
                        cmbNotCombineWith.SelectedItem = null;
                    }
                }
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            bool NaamBestaat = false;
            int intCounter = 0;
            foreach (Persoon aPerson in persoonLijst)
            {
                if (aPerson.Naam == txtName.Text)
                {
                    NaamBestaat = true;
                    lblError.Text = string.Empty;
                    persoonLijst.RemoveAt(intCounter);
                    if (cmbMaandag.SelectedItem != null)
                    {
                        aPerson.Maandag = Convert.ToInt32((cmbMaandag.SelectedItem as cmbItem).Value);
                    }
                    else
                    {
                        aPerson.Maandag = 0;
                    }
                    if (cmbDinsdag.SelectedItem != null)
                    {
                        aPerson.Dinsdag = Convert.ToInt32((cmbDinsdag.SelectedItem as cmbItem).Value);
                    }
                    else
                    {
                        aPerson.Dinsdag = 0;
                    }
                    if (cmbWoensdag.SelectedItem != null)
                    {
                        aPerson.Woensdag = Convert.ToInt32((cmbWoensdag.SelectedItem as cmbItem).Value);
                    }
                    else
                    {
                        aPerson.Woensdag = 0;
                    }
                    if (cmbDonderdag.SelectedItem != null)
                    {
                        aPerson.Donderdag = Convert.ToInt32((cmbDonderdag.SelectedItem as cmbItem).Value);
                    }
                    else
                    {
                        aPerson.Donderdag = 0;
                    }
                    if (cmbVrijdag.SelectedItem != null)
                    {
                        aPerson.Vrijdag = Convert.ToInt32((cmbVrijdag.SelectedItem as cmbItem).Value);
                    }
                    else
                    {
                        aPerson.Vrijdag = 0;
                    }
                    if (cmbZaterdag.SelectedItem != null)
                    {
                        aPerson.Zaterdag = Convert.ToInt32((cmbZaterdag.SelectedItem as cmbItem).Value);
                    }
                    else
                    {
                        aPerson.Zaterdag = 0;
                    }
                    if (cmbZondag.SelectedItem != null)
                    {
                        aPerson.Zondag = Convert.ToInt32((cmbZondag.SelectedItem as cmbItem).Value);
                    }
                    else
                    {
                        aPerson.Zondag = 0;
                    }
                    persoonLijst.Insert(intCounter, aPerson);
                    txtName.Text = string.Empty;
                    cmbMaandag.SelectedItem = null;
                    cmbDinsdag.SelectedItem = null;
                    cmbWoensdag.SelectedItem = null;
                    cmbDonderdag.SelectedItem = null;
                    cmbVrijdag.SelectedItem = null;
                    cmbZaterdag.SelectedItem = null;
                    cmbZondag.SelectedItem = null;
                    cmbNotCombineWith.SelectedItem = null;
                    ConvertPersonListToDL();
                    txtName.Enabled = true;
                    break;
                }
                intCounter++;
            }
            if (!NaamBestaat)
            {
                if (txtName.Text == string.Empty)
                {
                    lblError.Text = "Selecteer een persoon of vul een naam in.";
                }
                else
                {
                    lblError.Text = "Deze naam is niet in de lijst.";
                }
            }
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            bool NaamBestaat = false;
            int intCounter = 0;
            foreach (Persoon aPerson in persoonLijst)
            {
                if (aPerson.Naam == txtName.Text)
                {
                    NaamBestaat = true;
                    lblError.Text = string.Empty;
                    persoonLijst.RemoveAt(intCounter);
                    txtName.Text = string.Empty;
                    cmbMaandag.SelectedItem = null;
                    cmbDinsdag.SelectedItem = null;
                    cmbWoensdag.SelectedItem = null;
                    cmbDonderdag.SelectedItem = null;
                    cmbVrijdag.SelectedItem = null;
                    cmbZaterdag.SelectedItem = null;
                    cmbZondag.SelectedItem = null;
                    ConvertPersonListToDL();
                    txtName.Enabled = true;
                    break;
                }
                intCounter++;
            }
            if (!NaamBestaat)
            {
                if (txtName.Text == string.Empty)
                {
                    lblError.Text = "Selecteer een persoon of vul een naam in.";
                }
                else
                {
                    lblError.Text = "Deze naam is niet in de lijst.";
                }
            }
        }
        #endregion
        #region pnlData
        private void btnAddSpecific_Click(object sender, EventArgs e)
        {
            
            var tempDate = dateTimePicker1.Value;
            do{
                switch (tempDate.DayOfWeek){
                    case DayOfWeek.Monday: 
                        if (cbMaandag.Checked){
                            dataLijst.Add(new Datum()
                            {
                                Date = tempDate.ToString("dd/MM/yyyy"),
                                Weekdag = "Maandag"
                            });
                        }
                        break;
                    case DayOfWeek.Tuesday: 
                        if (cbDinsdag.Checked){
                            dataLijst.Add(new Datum()
                            {
                                Date = tempDate.ToString("dd/MM/yyyy"),
                                Weekdag = "Dinsdag"
                            });
                        }
                        break;
                    case DayOfWeek.Wednesday: 
                        if (cbWoensdag.Checked){
                            dataLijst.Add(new Datum()
                            {
                                Date = tempDate.ToString("dd/MM/yyyy"),
                                Weekdag = "Woensdag"
                            });
                        }
                        break;
                    case DayOfWeek.Thursday: 
                        if (cbDonderdag.Checked){
                            dataLijst.Add(new Datum()
                            {
                                Date = tempDate.ToString("dd/MM/yyyy"),
                                Weekdag = "Donderdag"
                            });
                        }
                        break;
                    case DayOfWeek.Friday: 
                        if (cbVrijdag.Checked){
                            dataLijst.Add(new Datum()
                            {
                                Date = tempDate.ToString("dd/MM/yyyy"),
                                Weekdag = "Vrijdag"
                            });
                        }
                        break;
                    case DayOfWeek.Saturday: 
                        if (cbZaterdag.Checked){
                            dataLijst.Add(new Datum()
                            {
                                Date = tempDate.ToString("dd/MM/yyyy"),
                                Weekdag = "Zaterdag"
                            });
                        }
                        break;
                    case DayOfWeek.Sunday: 
                        if (cbZondag.Checked){
                            dataLijst.Add(new Datum()
                            {
                                Date = tempDate.ToString("dd/MM/yyyy"),
                                Weekdag = "Zondag"
                            });
                        }
                        break;
                }
                tempDate = tempDate.AddDays(1);
            } while (tempDate.DayOfYear != dateTimePicker2.Value.DayOfYear);
            ConvertDataListToDLData();
        }
        private void ConvertDataListToDLData()
        {
            DLData.Rows.Clear();
            int intMaandagen = 0;
            int intDinsdagen = 0;
            int intWoensdagen = 0;
            int intDonderdagen = 0;
            int intVrijdagen = 0;
            int intZaterdagen = 0;
            int intZondagen = 0;
            if (dataLijst != null)
            {
                if (dataLijst.Count > 0)
                {
                    foreach (Datum aDate in dataLijst)
                    {
                        int intRowNumber = DLData.Rows.Add();
                        DLData.Rows[intRowNumber].Cells[0].Value = aDate.Date;
                        DLData.Rows[intRowNumber].Cells[1].Value = aDate.Weekdag;
                        switch (aDate.Weekdag)
                        {
                            case "Maandag":
                                intMaandagen++;
                                break;
                            case "Dinsdag":
                                intDinsdagen++;
                                break;
                            case "Woensdag":
                                intWoensdagen++;
                                break;
                            case "Donderdag":
                                intDonderdagen++;
                                break;
                            case "Vrijdag":
                                intVrijdagen++;
                                break;
                            case "Zaterdag":
                                intZaterdagen++;
                                break;
                            case "Zondag":
                                intZondagen++;
                                break;
                        }
                    }
                }
            }
            lblCMaandag.Text = "Maandagen: " + intMaandagen.ToString();
            lblCDinsdag.Text = "Dinsdagen: " + intDinsdagen.ToString();
            lblCWoensdag.Text = "Woensdagen: " + intWoensdagen.ToString();
            lblCDonderdag.Text = "Donderdagen: " + intDonderdagen.ToString();
            lblCVrijdag.Text = "Vrijdagen: " + intVrijdagen.ToString();
            lblCZaterdag.Text = "Zaterdagen: " + intZaterdagen.ToString();
            lblCZondag.Text = "Zondagen: " + intZondagen.ToString();
        }
        private void btnRemoveSpecific_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dlDataSelectedRow in DLData.SelectedRows){
                dataLijst.RemoveAll(x => x.Date == dlDataSelectedRow.Cells[0].Value.ToString());
            }
            ConvertDataListToDLData();
        }
        #endregion
        #region pnlGenerate
        private void GenerateOutput(int intAantalKolommen, int intAantalRijen, int intAantalAutos, List<string> Weekdagen, string strPath, string strButtonID)
        {
            List<string> output = new List<string>();
            string strTempOutput = string.Empty;
            string s = ";";
            bool PersonenToegevoegd = false;
            bool NamenGelukt = true;

            //Sorteer de data op datum (niet op weekdagen want das veel moeilijker om te gebruiken)
            SorteerData();

            List<string> tempoutput = new List<string>();
            for (int intCounter = 0; intCounter < 3; intCounter++)
            {
                if (intCounter == 0)
                {
                    for (int intCdag = 0; intCdag < Weekdagen.Count; intCdag++)
                    {
                        for (int intCauto = 1; intCauto <= intAantalAutos; intCauto++)
                        {
                            strTempOutput += "AUTO " + intCauto.ToString() + " - " + Weekdagen[intCdag] + s + s + s;
                        }
                        if (Weekdagen[Weekdagen.Count - 1] != Weekdagen[intCdag])
                        {
                            strTempOutput += s;
                        }
                    }
                }
                else if (intCounter == 1)
                { //Als het de tweede rij is
                    for (int intCdag = 0; intCdag < Weekdagen.Count; intCdag++)
                    { //Voor elke dag
                        for (int intCauto = 1; intCauto <= intAantalAutos; intCauto++)
                        { //Voor elke auto
                            strTempOutput += s + "heen" + s + "terug" + s;
                        }
                        //Deze is een kolom dat voorzien wordt om het schema op te splitsen per auto (voor een beter overzicht)
                        if ((intCdag + 1) != Weekdagen.Count)
                        {
                            strTempOutput += s;
                        }
                    }
                }
                else
                {//Vanaf hier begint het echte werk met data en personen (eerst de data)
                    List<string> datalines = new List<string>();
                    if (strButtonID == "btnGenerateZonderNamen")
                    {
                        datalines = GenerateDataLines(intAantalAutos, (intAantalRijen - 2), Weekdagen, s);
                        PersonenToegevoegd = true;
                    }
                    else
                    {
                        if (persoonLijst != null)
                        {
                            if (persoonLijst.Count > 0)
                            {
                                PersonenToegevoegd = true;
                            }
                        }
                        if (PersonenToegevoegd)
                        {
                            datalines = GenerateNamenLines(intAantalAutos, (intAantalRijen - 2), Weekdagen, s);
                            if (datalines.Count > 0)
                            {
                                NamenGelukt = true;
                            }
                            else
                            {
                                NamenGelukt = false;
                            }
                        }
                    }
                    foreach (string line in datalines)
                    {
                        output.Add(line);
                    }
                    //for ()
                    //{
                    //    for (int intCdag = 0; intCdag < Weekdagen.Count; intCdag++)
                    //    {
                    //        string strDatum = GetDateInString(dataLijst[intCounter - 2]);
                    //        strTempOutput += strDatum + s + s + s;
                    //    }
                    //    //Deze is een kolom dat voorzien wordt om het schema op te splitsen per auto (voor een beter overzicht)
                    //    if ((intCauto + 1) <= intAantalAutos)
                    //    {
                    //        strTempOutput += s;
                    //    }
                    //}
                }
                output.Add(strTempOutput);
                strTempOutput = string.Empty;
            }
            if (PersonenToegevoegd)
            {
                if (strButtonID != "btnGenerateZonderNamen" && !NamenGelukt)
                { //Geen csv bestand maken

                }
                else
                {
                    WriteCSVFile(strPath, output);
                }
            }
            else
            {
                lblError.Text = "Voeg personen toe om het schema in te vullen.";
            }
        }
        private string ConvertDateToString(Datum aDate)
        {
            string[] date = aDate.Date.Split('/');
            int intMaand = Convert.ToInt32(date[1]);
            string strMaand = string.Empty;
            if (cbShortMaand.Checked)
            {
                switch (intMaand)
                {
                    case 1:
                        strMaand = "jan.";
                        break;
                    case 2:
                        strMaand = "feb.";
                        break;
                    case 3:
                        strMaand = "mrt.";
                        break;
                    case 4:
                        strMaand = "apr.";
                        break;
                    case 5:
                        strMaand = "mei";
                        break;
                    case 6:
                        strMaand = "jun.";
                        break;
                    case 7:
                        strMaand = "jul.";
                        break;
                    case 8:
                        strMaand = "aug.";
                        break;
                    case 9:
                        strMaand = "sep.";
                        break;
                    case 10:
                        strMaand = "okt.";
                        break;
                    case 11:
                        strMaand = "nov.";
                        break;
                    case 12:
                        strMaand = "dec.";
                        break;
                }
            }
            else
            {
                switch (intMaand)
                {
                    case 1:
                        strMaand = "januari";
                        break;
                    case 2:
                        strMaand = "februari";
                        break;
                    case 3:
                        strMaand = "maart";
                        break;
                    case 4:
                        strMaand = "april";
                        break;
                    case 5:
                        strMaand = "mei";
                        break;
                    case 6:
                        strMaand = "juni";
                        break;
                    case 7:
                        strMaand = "juli";
                        break;
                    case 8:
                        strMaand = "augustus";
                        break;
                    case 9:
                        strMaand = "september";
                        break;
                    case 10:
                        strMaand = "oktober";
                        break;
                    case 11:
                        strMaand = "november";
                        break;
                    case 12:
                        strMaand = "december";
                        break;
                }
            }
            string strDefDate = date[0] + "-" + strMaand;
            if (cbShowYear.Checked)
            {
                strDefDate += "-" + date[2];
            }
            return strDefDate;
        }
        private void WriteCSVFile(string strPath, List<string> output)
        {
            bool worked = false;
            int intCounter = 1;
            while (!worked)
            {
                try
                {
                    string temp = string.Empty;
                    if (intCounter > 1)
                    {
                        string[] x = strPath.Split('.');
                        temp = x[0] + "_" + intCounter.ToString() + "." + x[1];
                    }
                    else
                    {
                        temp = strPath;
                    }
                    File.WriteAllLines(temp, output);
                    worked = true;
                    System.Diagnostics.Process.Start(strPath);
                }
                catch (Exception ex)
                {
                    worked = false;
                    intCounter++;
                }
            }
        }
        private void btnGenerateCSV_Click(object sender, EventArgs e)
        {
            if (cmbAantalAutos.Text != string.Empty && cmbMaxPassagiers.Text != string.Empty)
            {
                lblError.Text = string.Empty;
                intMaxAantalPassagiers = Convert.ToInt32(cmbMaxPassagiers.Text);
                string strDatum = DateTime.Now.ToString().Replace("-", string.Empty);
                string[] strsplitteddate = strDatum.Split(':');
                string strTemp = strsplitteddate[0] + "u" + strsplitteddate[1];
                string[] strsplitdate = strDatum.Split(' ');
                strsplitteddate = strTemp.Split(' ');
                strTemp = strsplitteddate[1];
                string strDate = strsplitdate[0] + "_" + strTemp;
                string strPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\RijSchema_" + strDate.Replace("\\",string.Empty).Replace("/",string.Empty) + ".csv";
                int intAantalWeekdagen = 0;
                List<string> Weekdagen = new List<string>();
                if (cbMaandag.Checked)
                {
                    Weekdagen.Add("Maandag");
                }
                if (cbDinsdag.Checked)
                {
                    Weekdagen.Add("Dinsdag");
                }
                if (cbWoensdag.Checked)
                {
                    Weekdagen.Add("Woensdag");
                }
                if (cbDonderdag.Checked)
                {
                    Weekdagen.Add("Donderdag");
                }
                if (cbVrijdag.Checked)
                {
                    Weekdagen.Add("Vrijdag");
                }
                if (cbZaterdag.Checked)
                {
                    Weekdagen.Add("Zaterdag");
                }
                if (cbZondag.Checked)
                {
                    Weekdagen.Add("Zondag");
                }
                if (Weekdagen != null)
                {
                    intAantalWeekdagen = Weekdagen.Count;
                }
                if (intAantalWeekdagen != 0)
                {
                    if (dataLijst != null)
                    {
                        if (dataLijst.Count != 0)
                        {
                            intAantalAutos = Convert.ToInt32(cmbAantalAutos.Text);
                            int intAantalKolomen = intAantalAutos * 3 * intAantalWeekdagen + (intAantalWeekdagen - 1);
                            int intAantalRijen = 2 + dataLijst.Count;
                            //MessageBox.Show("Kolommen: " + intAantalKolomen.ToString() + Environment.NewLine + "Rijen: " + intAantalRijen.ToString());
                            GenerateOutput(intAantalKolomen, intAantalRijen, intAantalAutos, Weekdagen, strPath, (sender as Button).Name);
                        }
                        else
                        {
                            lblError.Text = "Er moet minstens 1 datum ingevuld worden.";
                        }
                    }
                    else
                    {
                        lblError.Text = "Er zijn nog geen data ingevuld.";
                    }
                }
                else
                {
                    lblError.Text = "Duid minstens 1 dag aan.";
                }
            }
            else
            {
                if (cmbAantalAutos.Text == string.Empty)
                {
                    lblError.Text = "Selecteer hoeveel auto's er zijn.";
                }
                else
                {
                    lblError.Text = "Selecteer het maximum aantal passagiers.";
                }
            }
        }
        private List<string> GenerateDataLines(int intAantalAutos, int intAantalRijen, List<string> Weekdagen, string s)
        { //Datalijst is gesorteerd op datum (+ header is al aangemaakt)
          //hier gewoon sorteren dag, dan op met of zonder namen en dan op auto

            List<string> tempoutput = new List<string>();

            List<Datum> Maandagen = new List<Datum>();
            List<Datum> Dinsdagen = new List<Datum>();
            List<Datum> Woensdagen = new List<Datum>();
            List<Datum> Donderdagen = new List<Datum>();
            List<Datum> Vrijdagen = new List<Datum>();
            List<Datum> Zaterdagen = new List<Datum>();
            List<Datum> Zondagen = new List<Datum>();

            int intMaxRijen = 0;
            if (Weekdagen.Contains("Maandag"))
            {
                int intMaandagen = 0;
                foreach (Datum aDate in dataLijst)
                {
                    if (aDate.Weekdag == "Maandag")
                    {
                        Datum bDate = new Datum();
                        bDate.Date = ConvertDateToString(aDate);
                        bDate.Weekdag = aDate.Weekdag;
                        Maandagen.Add(bDate);
                        intMaandagen++;
                    }
                }
                if (intMaandagen > intMaxRijen)
                {
                    intMaxRijen = intMaandagen;
                }
            }
            if (Weekdagen.Contains("Dinsdag"))
            {
                int intDinsdagen = 0;
                foreach (Datum aDate in dataLijst)
                {
                    if (aDate.Weekdag == "Dinsdag")
                    {
                        Datum bDate = new Datum();
                        bDate.Date = ConvertDateToString(aDate);
                        bDate.Weekdag = aDate.Weekdag;
                        Dinsdagen.Add(bDate);
                        intDinsdagen++;
                    }
                }
                if (intDinsdagen > intMaxRijen)
                {
                    intMaxRijen = intDinsdagen;
                }
            }
            if (Weekdagen.Contains("Woensdag"))
            {
                int intWoensdagen = 0;
                foreach (Datum aDate in dataLijst)
                {
                    if (aDate.Weekdag == "Woensdag")
                    {
                        Datum bDate = new Datum();
                        bDate.Date = ConvertDateToString(aDate);
                        bDate.Weekdag = aDate.Weekdag;
                        Woensdagen.Add(bDate);
                        intWoensdagen++;
                    }
                }
                if (intWoensdagen > intMaxRijen)
                {
                    intMaxRijen = intWoensdagen;
                }
            }
            if (Weekdagen.Contains("Donderdag"))
            {
                int intDonderdagen = 0;
                foreach (Datum aDate in dataLijst)
                {
                    if (aDate.Weekdag == "Donderdag")
                    {
                        Datum bDate = new Datum();
                        bDate.Date = ConvertDateToString(aDate);
                        bDate.Weekdag = aDate.Weekdag;
                        Donderdagen.Add(bDate);
                        intDonderdagen++;
                    }
                }
                if (intDonderdagen > intMaxRijen)
                {
                    intMaxRijen = intDonderdagen;
                }
            }
            if (Weekdagen.Contains("Vrijdag"))
            {
                int intVrijdagen = 0;
                foreach (Datum aDate in dataLijst)
                {
                    if (aDate.Weekdag == "Vrijdag")
                    {
                        Datum bDate = new Datum();
                        bDate.Date = ConvertDateToString(aDate);
                        bDate.Weekdag = aDate.Weekdag;
                        Vrijdagen.Add(bDate);
                        intVrijdagen++;
                    }
                }
                if (intVrijdagen > intMaxRijen)
                {
                    intMaxRijen = intVrijdagen;
                }
            }
            if (Weekdagen.Contains("Zaterdag"))
            {
                int intZaterdagen = 0;
                foreach (Datum aDate in dataLijst)
                {
                    if (aDate.Weekdag == "Zaterdag")
                    {
                        Datum bDate = new Datum();
                        bDate.Date = ConvertDateToString(aDate);
                        bDate.Weekdag = aDate.Weekdag;
                        Zaterdagen.Add(bDate);
                        intZaterdagen++;
                    }
                }
                if (intZaterdagen > intMaxRijen)
                {
                    intMaxRijen = intZaterdagen;
                }
            }
            if (Weekdagen.Contains("Zondag"))
            {
                int intZondagen = 0;
                foreach (Datum aDate in dataLijst)
                {
                    if (aDate.Weekdag == "Zondag")
                    {
                        Datum bDate = new Datum();
                        bDate.Date = ConvertDateToString(aDate);
                        bDate.Weekdag = aDate.Weekdag;
                        Zondagen.Add(bDate);
                        intZondagen++;
                    }
                }
                if (intZondagen > intMaxRijen)
                {
                    intMaxRijen = intZondagen;
                }
            }

            int intAantalWeekdagen = Weekdagen.Count;

            for (int intCounter = 0; intCounter < intAantalRijen; intCounter++)
            { //Gaat elke rij af
                string strOutput = string.Empty;
                //Sorteer per dag
                if (Weekdagen.Contains("Maandag"))
                {
                    if (Maandagen != null)
                    {
                        if (Maandagen.Count > intCounter)
                        { //for loop voor het aantal autos
                            for (int intCounterauto = 0; intCounterauto < intAantalAutos; intCounterauto++)
                            {
                                strOutput += Maandagen[intCounter].Date + s + s + s;
                            }
                            if (Weekdagen[Weekdagen.Count - 1] != "Maandag")
                            {
                                strOutput += s;
                            }
                        }
                        else if (intCounter < intMaxRijen)
                        { //for loop om leegtes op te vullen tussen dagen
                            for (int intCounterauto = 0; intCounterauto < intAantalAutos; intCounterauto++)
                            {
                                strOutput += s + s + s;
                            }
                            if (Weekdagen[Weekdagen.Count - 1] != "Maandag")
                            {
                                strOutput += s;
                            }
                        }
                    }
                }
                if (Weekdagen.Contains("Dinsdag"))
                {
                    if (Dinsdagen != null)
                    {
                        if (Dinsdagen.Count > intCounter)
                        {//for loop voor het aantal autos
                            for (int intCounterauto = 0; intCounterauto < intAantalAutos; intCounterauto++)
                            {
                                strOutput += Dinsdagen[intCounter].Date + s + s + s;
                            }
                            if (Weekdagen[Weekdagen.Count - 1] != "Dinsdag")
                            {
                                strOutput += s;
                            }
                        }
                        else if (intCounter < intMaxRijen)
                        { //for loop om leegtes op te vullen tussen dagen
                            for (int intCounterauto = 0; intCounterauto < intAantalAutos; intCounterauto++)
                            {
                                strOutput += s + s + s;
                            }
                            if (Weekdagen[Weekdagen.Count - 1] != "Dinsdag")
                            {
                                strOutput += s;
                            }
                        }
                    }
                }
                if (Weekdagen.Contains("Woensdag"))
                {
                    if (Woensdagen != null)
                    {
                        if (Woensdagen.Count > intCounter)
                        {//for loop voor het aantal autos
                            for (int intCounterauto = 0; intCounterauto < intAantalAutos; intCounterauto++)
                            {
                                strOutput += Woensdagen[intCounter].Date + s + s + s;
                            }
                            if (Weekdagen[Weekdagen.Count - 1] != "Woensdag")
                            {
                                strOutput += s;
                            }
                        }
                        else if (intCounter < intMaxRijen)
                        { //for loop om leegtes op te vullen tussen dagen
                            for (int intCounterauto = 0; intCounterauto < intAantalAutos; intCounterauto++)
                            {
                                strOutput += s + s + s;
                            }
                            if (Weekdagen[Weekdagen.Count - 1] != "Woensdag")
                            {
                                strOutput += s;
                            }
                        }
                    }
                }
                if (Weekdagen.Contains("Donderdag"))
                {
                    if (Donderdagen != null)
                    {
                        if (Donderdagen.Count > intCounter)
                        {//for loop voor het aantal autos
                            for (int intCounterauto = 0; intCounterauto < intAantalAutos; intCounterauto++)
                            {
                                strOutput += Donderdagen[intCounter].Date + s + s + s;
                            }
                            if (Weekdagen[Weekdagen.Count - 1] != "Donderdag")
                            {
                                strOutput += s;
                            }
                        }
                        else if (intCounter < intMaxRijen)
                        { //for loop om leegtes op te vullen tussen dagen
                            for (int intCounterauto = 0; intCounterauto < intAantalAutos; intCounterauto++)
                            {
                                strOutput += s + s + s;
                            }
                            if (Weekdagen[Weekdagen.Count - 1] != "Donderdag")
                            {
                                strOutput += s;
                            }
                        }
                    }
                }
                if (Weekdagen.Contains("Vrijdag"))
                {
                    if (Vrijdagen != null)
                    {
                        if (Vrijdagen.Count > intCounter)
                        {//for loop voor het aantal autos
                            for (int intCounterauto = 0; intCounterauto < intAantalAutos; intCounterauto++)
                            {
                                strOutput += Vrijdagen[intCounter].Date + s + s + s;
                            }
                            if (Weekdagen[Weekdagen.Count - 1] != "Vrijdag")
                            {
                                strOutput += s;
                            }
                        }
                        else if (intCounter < intMaxRijen)
                        { //for loop om leegtes op te vullen tussen dagen
                            for (int intCounterauto = 0; intCounterauto < intAantalAutos; intCounterauto++)
                            {
                                strOutput += s + s + s;
                            }
                            if (Weekdagen[Weekdagen.Count - 1] != "Vrijdag")
                            {
                                strOutput += s;
                            }
                        }
                    }
                }
                if (Weekdagen.Contains("Zaterdag"))
                {
                    if (Zaterdagen != null)
                    {
                        if (Zaterdagen.Count > intCounter)
                        {//for loop voor het aantal autos
                            for (int intCounterauto = 0; intCounterauto < intAantalAutos; intCounterauto++)
                            {
                                strOutput += Zaterdagen[intCounter].Date + s + s + s;
                            }
                            if (Weekdagen[Weekdagen.Count - 1] != "Zaterdag")
                            {
                                strOutput += s;
                            }
                        }
                        else if (intCounter < intMaxRijen)
                        { //for loop om leegtes op te vullen tussen dagen
                            for (int intCounterauto = 0; intCounterauto < intAantalAutos; intCounterauto++)
                            {
                                strOutput += s + s + s;
                            }
                            if (Weekdagen[Weekdagen.Count - 1] != "Zaterdag")
                            {
                                strOutput += s;
                            }
                        }
                    }
                }
                if (Weekdagen.Contains("Zondag"))
                {
                    if (Zondagen != null)
                    {
                        if (Zondagen.Count > intCounter)
                        {//for loop voor het aantal autos
                            for (int intCounterauto = 0; intCounterauto < intAantalAutos; intCounterauto++)
                            {
                                strOutput += Zondagen[intCounter].Date + s + s + s;
                            }
                        }
                        else if (intCounter < intMaxRijen)
                        { //for loop om leegtes op te vullen tussen dagen
                            for (int intCounterauto = 0; intCounterauto < intAantalAutos; intCounterauto++)
                            {
                                strOutput += s + s + s;
                            }
                        }
                    }
                }

                tempoutput.Add(strOutput);
            }
            return tempoutput;
        }
        private List<string> GenerateNamenLines(int intAantalAutos, int intAantalRijen, List<string> Weekdagen, string s)
        { //Datalijst is gesorteerd op datum (+ header is al aangemaakt)
          //hier gewoon sorteren dag, dan op met of zonder namen en dan op auto

            List<string> tempoutput = new List<string>();

            List<Datum> Maandagen = new List<Datum>();
            List<Datum> Dinsdagen = new List<Datum>();
            List<Datum> Woensdagen = new List<Datum>();
            List<Datum> Donderdagen = new List<Datum>();
            List<Datum> Vrijdagen = new List<Datum>();
            List<Datum> Zaterdagen = new List<Datum>();
            List<Datum> Zondagen = new List<Datum>();

            int intMaxRijen = 0;
            if (Weekdagen.Contains("Maandag"))
            {
                int intMaandagen = 0;
                foreach (Datum aDate in dataLijst)
                {
                    if (aDate.Weekdag == "Maandag")
                    {
                        Datum bDate = new Datum();
                        bDate.Date = ConvertDateToString(aDate);
                        bDate.Weekdag = aDate.Weekdag;
                        Maandagen.Add(bDate);
                        intMaandagen++;
                    }
                }
                if (intMaandagen > intMaxRijen)
                {
                    intMaxRijen = intMaandagen;
                }
            }
            if (Weekdagen.Contains("Dinsdag"))
            {
                int intDinsdagen = 0;
                foreach (Datum aDate in dataLijst)
                {
                    if (aDate.Weekdag == "Dinsdag")
                    {
                        Datum bDate = new Datum();
                        bDate.Date = ConvertDateToString(aDate);
                        bDate.Weekdag = aDate.Weekdag;
                        Dinsdagen.Add(bDate);
                        intDinsdagen++;
                    }
                }
                if (intDinsdagen > intMaxRijen)
                {
                    intMaxRijen = intDinsdagen;
                }
            }
            if (Weekdagen.Contains("Woensdag"))
            {
                int intWoensdagen = 0;
                foreach (Datum aDate in dataLijst)
                {
                    if (aDate.Weekdag == "Woensdag")
                    {
                        Datum bDate = new Datum();
                        bDate.Date = ConvertDateToString(aDate);
                        bDate.Weekdag = aDate.Weekdag;
                        Woensdagen.Add(bDate);
                        intWoensdagen++;
                    }
                }
                if (intWoensdagen > intMaxRijen)
                {
                    intMaxRijen = intWoensdagen;
                }
            }
            if (Weekdagen.Contains("Donderdag"))
            {
                int intDonderdagen = 0;
                foreach (Datum aDate in dataLijst)
                {
                    if (aDate.Weekdag == "Donderdag")
                    {
                        Datum bDate = new Datum();
                        bDate.Date = ConvertDateToString(aDate);
                        bDate.Weekdag = aDate.Weekdag;
                        Donderdagen.Add(bDate);
                        intDonderdagen++;
                    }
                }
                if (intDonderdagen > intMaxRijen)
                {
                    intMaxRijen = intDonderdagen;
                }
            }
            if (Weekdagen.Contains("Vrijdag"))
            {
                int intVrijdagen = 0;
                foreach (Datum aDate in dataLijst)
                {
                    if (aDate.Weekdag == "Vrijdag")
                    {
                        Datum bDate = new Datum();
                        bDate.Date = ConvertDateToString(aDate);
                        bDate.Weekdag = aDate.Weekdag;
                        Vrijdagen.Add(bDate);
                        intVrijdagen++;
                    }
                }
                if (intVrijdagen > intMaxRijen)
                {
                    intMaxRijen = intVrijdagen;
                }
            }
            if (Weekdagen.Contains("Zaterdag"))
            {
                int intZaterdagen = 0;
                foreach (Datum aDate in dataLijst)
                {
                    if (aDate.Weekdag == "Zaterdag")
                    {
                        Datum bDate = new Datum();
                        bDate.Date = ConvertDateToString(aDate);
                        bDate.Weekdag = aDate.Weekdag;
                        Zaterdagen.Add(bDate);
                        intZaterdagen++;
                    }
                }
                if (intZaterdagen > intMaxRijen)
                {
                    intMaxRijen = intZaterdagen;
                }
            }
            if (Weekdagen.Contains("Zondag"))
            {
                int intZondagen = 0;
                foreach (Datum aDate in dataLijst)
                {
                    if (aDate.Weekdag == "Zondag")
                    {
                        Datum bDate = new Datum();
                        bDate.Date = ConvertDateToString(aDate);
                        bDate.Weekdag = aDate.Weekdag;
                        Zondagen.Add(bDate);
                        intZondagen++;
                    }
                }
                if (intZondagen > intMaxRijen)
                {
                    intMaxRijen = intZondagen;
                }
            }

            GenerateRijders(intAantalAutos, intAantalRijen, Weekdagen);
            if (NamenLijstDagDatumAutosHT.Count > 0)
            {
                int intAantalWeekdagen = Weekdagen.Count;
                int intHT1;
                int intHT2;

                for (int intCounter = 0; intCounter < intAantalRijen; intCounter++)
                { //Gaat elke rij af
                    string strOutput = string.Empty;
                    //Sorteer per dag
                    if (Weekdagen.Contains("Maandag"))
                    {
                        intHT1 = 0;
                        if (Maandagen != null)
                        {
                            if (Maandagen.Count > intCounter)
                            { //for loop voor het aantal autos
                                for (int intCounterauto = 0; intCounterauto < intAantalAutos; intCounterauto++)
                                {
                                    intHT2 = intCounter;
                                    string strHeen = GenerateStrHeen(intHT1, intHT2, intCounterauto);
                                    string strTerug = GenerateStrTerug(intHT1, intHT2, intCounterauto);
                                    strOutput += Maandagen[intCounter].Date + s + strHeen + s + strTerug + s;
                                }
                                if (Weekdagen[Weekdagen.Count - 1] != "Maandag")
                                {
                                    strOutput += s;
                                }
                            }
                            else if (intCounter < intMaxRijen)
                            { //for loop om leegtes op te vullen tussen dagen
                                for (int intCounterauto = 0; intCounterauto < intAantalAutos; intCounterauto++)
                                {
                                    strOutput += s + s + s;
                                }
                                if (Weekdagen[Weekdagen.Count - 1] != "Maandag")
                                {
                                    strOutput += s;
                                }
                            }
                        }
                    }
                    if (Weekdagen.Contains("Dinsdag"))
                    {
                        intHT1 = 1;
                        if (Dinsdagen != null)
                        {
                            if (Dinsdagen.Count > intCounter)
                            {//for loop voor het aantal autos
                                for (int intCounterauto = 0; intCounterauto < intAantalAutos; intCounterauto++)
                                {
                                    intHT2 = intCounter;
                                    string strHeen = GenerateStrHeen(intHT1, intHT2, intCounterauto);
                                    string strTerug = GenerateStrTerug(intHT1, intHT2, intCounterauto);
                                    strOutput += Dinsdagen[intCounter].Date + s + strHeen + s + strTerug + s;
                                }
                                if (Weekdagen[Weekdagen.Count - 1] != "Dinsdag")
                                {
                                    strOutput += s;
                                }
                            }
                            else if (intCounter < intMaxRijen)
                            { //for loop om leegtes op te vullen tussen dagen
                                for (int intCounterauto = 0; intCounterauto < intAantalAutos; intCounterauto++)
                                {
                                    strOutput += s + s + s;
                                }
                                if (Weekdagen[Weekdagen.Count - 1] != "Dinsdag")
                                {
                                    strOutput += s;
                                }
                            }
                        }
                    }
                    if (Weekdagen.Contains("Woensdag"))
                    {
                        intHT1 = 2;
                        if (Woensdagen != null)
                        {
                            if (Woensdagen.Count > intCounter)
                            {//for loop voor het aantal autos
                                for (int intCounterauto = 0; intCounterauto < intAantalAutos; intCounterauto++)
                                {
                                    intHT2 = intCounter;
                                    string strHeen = GenerateStrHeen(intHT1, intHT2, intCounterauto);
                                    string strTerug = GenerateStrTerug(intHT1, intHT2, intCounterauto);
                                    strOutput += Woensdagen[intCounter].Date + s + strHeen + s + strTerug + s;
                                }
                                if (Weekdagen[Weekdagen.Count - 1] != "Woensdag")
                                {
                                    strOutput += s;
                                }
                            }
                            else if (intCounter < intMaxRijen)
                            { //for loop om leegtes op te vullen tussen dagen
                                for (int intCounterauto = 0; intCounterauto < intAantalAutos; intCounterauto++)
                                {
                                    strOutput += s + s + s;
                                }
                                if (Weekdagen[Weekdagen.Count - 1] != "Woensdag")
                                {
                                    strOutput += s;
                                }
                            }
                        }
                    }
                    if (Weekdagen.Contains("Donderdag"))
                    {
                        intHT1 = 3;
                        if (Donderdagen != null)
                        {
                            if (Donderdagen.Count > intCounter)
                            {//for loop voor het aantal autos
                                for (int intCounterauto = 0; intCounterauto < intAantalAutos; intCounterauto++)
                                {
                                    intHT2 = intCounter;
                                    string strHeen = GenerateStrHeen(intHT1, intHT2, intCounterauto);
                                    string strTerug = GenerateStrTerug(intHT1, intHT2, intCounterauto);
                                    strOutput += Donderdagen[intCounter].Date + s + strHeen + s + strTerug + s;
                                }
                                if (Weekdagen[Weekdagen.Count - 1] != "Donderdag")
                                {
                                    strOutput += s;
                                }
                            }
                            else if (intCounter < intMaxRijen)
                            { //for loop om leegtes op te vullen tussen dagen
                                for (int intCounterauto = 0; intCounterauto < intAantalAutos; intCounterauto++)
                                {
                                    strOutput += s + s + s;
                                }
                                if (Weekdagen[Weekdagen.Count - 1] != "Donderdag")
                                {
                                    strOutput += s;
                                }
                            }
                        }
                    }
                    if (Weekdagen.Contains("Vrijdag"))
                    {
                        intHT1 = 4;
                        if (Vrijdagen != null)
                        {
                            if (Vrijdagen.Count > intCounter)
                            {//for loop voor het aantal autos
                                for (int intCounterauto = 0; intCounterauto < intAantalAutos; intCounterauto++)
                                {
                                    intHT2 = intCounter;
                                    string strHeen = GenerateStrHeen(intHT1, intHT2, intCounterauto);
                                    string strTerug = GenerateStrTerug(intHT1, intHT2, intCounterauto);
                                    strOutput += Vrijdagen[intCounter].Date + s + strHeen + s + strTerug + s;
                                }
                                if (Weekdagen[Weekdagen.Count - 1] != "Vrijdag")
                                {
                                    strOutput += s;
                                }
                            }
                            else if (intCounter < intMaxRijen)
                            { //for loop om leegtes op te vullen tussen dagen
                                for (int intCounterauto = 0; intCounterauto < intAantalAutos; intCounterauto++)
                                {
                                    strOutput += s + s + s;
                                }
                                if (Weekdagen[Weekdagen.Count - 1] != "Vrijdag")
                                {
                                    strOutput += s;
                                }
                            }
                        }
                    }
                    if (Weekdagen.Contains("Zaterdag"))
                    {
                        intHT1 = 5;
                        if (Zaterdagen != null)
                        {
                            if (Zaterdagen.Count > intCounter)
                            {//for loop voor het aantal autos
                                for (int intCounterauto = 0; intCounterauto < intAantalAutos; intCounterauto++)
                                {
                                    intHT2 = intCounter;
                                    string strHeen = GenerateStrHeen(intHT1, intHT2, intCounterauto);
                                    string strTerug = GenerateStrTerug(intHT1, intHT2, intCounterauto);
                                    strOutput += Zaterdagen[intCounter].Date + s + strHeen + s + strTerug + s;
                                }
                                if (Weekdagen[Weekdagen.Count - 1] != "Zaterdag")
                                {
                                    strOutput += s;
                                }
                            }
                            else if (intCounter < intMaxRijen)
                            { //for loop om leegtes op te vullen tussen dagen
                                for (int intCounterauto = 0; intCounterauto < intAantalAutos; intCounterauto++)
                                {
                                    strOutput += s + s + s;
                                }
                                if (Weekdagen[Weekdagen.Count - 1] != "Zaterdag")
                                {
                                    strOutput += s;
                                }
                            }
                        }
                    }
                    if (Weekdagen.Contains("Zondag"))
                    {
                        intHT1 = 6;
                        if (Zondagen != null)
                        {
                            if (Zondagen.Count > intCounter)
                            {//for loop voor het aantal autos
                                for (int intCounterauto = 0; intCounterauto < intAantalAutos; intCounterauto++)
                                {
                                    intHT2 = intCounter;
                                    string strHeen = GenerateStrHeen(intHT1, intHT2, intCounterauto);
                                    string strTerug = GenerateStrTerug(intHT1, intHT2, intCounterauto);
                                    strOutput += Zondagen[intCounter].Date + s + strHeen + s + strTerug + s;
                                }
                            }
                            else if (intCounter < intMaxRijen)
                            { //for loop om leegtes op te vullen tussen dagen
                                for (int intCounterauto = 0; intCounterauto < intAantalAutos; intCounterauto++)
                                {
                                    strOutput += s + s + s;
                                }
                            }
                        }
                    }

                    tempoutput.Add(strOutput);
                }
                NamenLijstDagDatumAutosHT = new List<List<WDag>>();
            }
            else
            {
                tempoutput = new List<string>();
            }

            return tempoutput;
        }
        private void GenerateRijders(int intAantalAutos, int intAantalRijen, List<string> Weekdagen)
        {
            List<WDag> Maandag = new List<WDag>();
            List<WDag> Dinsdag = new List<WDag>();
            List<WDag> Woensdag = new List<WDag>();
            List<WDag> Donderdag = new List<WDag>();
            List<WDag> Vrijdag = new List<WDag>();
            List<WDag> Zaterdag = new List<WDag>();
            List<WDag> Zondag = new List<WDag>();


            //Er is al gecontroleerd of alle waardes niet null zijn (geen enkele waarde dat je nodig hebt is null)
            int intAantalPersonen = persoonLijst.Count;

            //Check of het wel mogelijk is om met het gegeven aantal autos het aantal personen te vervoeren
            bool IsMogelijk = true;
            int intAantalVervoerd = intAantalAutos * intMaxAantalPassagiers + intAantalAutos;
            if (intAantalVervoerd >= intAantalPersonen)
            { //Het is mogelijk
                lblError.Text = string.Empty;
            }
            else
            { //Het is niet mogelijk
                lblError.Text = "Het is niet mogelijk om met dit aantal auto's en maximum aantal passagiers iedereen te vervoeren.";
                IsMogelijk = false;
            }

            bool MixBestuurders = false;
            bool MixPassagiers = false;
            if (cmbMixen.Text == "Passagiers" || cmbMixen.Text == "Bestuurders & Passagiers")
            {
                MixPassagiers = true;
            }
            if (cmbMixen.Text == "Bestuurders" || cmbMixen.Text == "Bestuurders & Passagiers")
            {
                MixBestuurders = true;
            }

            int intStartHeenRijder = 0;
            int intStartTerugRijder = 1;
            foreach (string dag in Weekdagen)
            { //Voor elke dag
                //Get the drivers from this day and all the people who need to go on this day
                List<Persoon> mogelijkseheenrijders = new List<Persoon>();
                List<Persoon> mogelijkseterugrijders = new List<Persoon>();
                List<Persoon> iedereenDieMeeMoet = new List<Persoon>();
                foreach (Persoon aPerson in persoonLijst)
                {
                    if (dag == "Maandag")
                    {
                        switch (aPerson.Maandag)
                        {
                            case 1:
                                mogelijkseheenrijders.Add(aPerson);
                                iedereenDieMeeMoet.Add(aPerson);
                                break;
                            case 2:
                                mogelijkseterugrijders.Add(aPerson);
                                iedereenDieMeeMoet.Add(aPerson);
                                break;
                            case 3:
                                mogelijkseheenrijders.Add(aPerson);
                                mogelijkseterugrijders.Add(aPerson);
                                iedereenDieMeeMoet.Add(aPerson);
                                break;
                            case 4:
                                iedereenDieMeeMoet.Add(aPerson);
                                break;

                        }
                    }
                    if (dag == "Dinsdag")
                    {
                        switch (aPerson.Dinsdag)
                        {
                            case 1:
                                mogelijkseheenrijders.Add(aPerson);
                                iedereenDieMeeMoet.Add(aPerson);
                                break;
                            case 2:
                                mogelijkseterugrijders.Add(aPerson);
                                iedereenDieMeeMoet.Add(aPerson);
                                break;
                            case 3:
                                mogelijkseheenrijders.Add(aPerson);
                                mogelijkseterugrijders.Add(aPerson);
                                iedereenDieMeeMoet.Add(aPerson);
                                break;
                            case 4:
                                iedereenDieMeeMoet.Add(aPerson);
                                break;

                        }
                    }
                    if (dag == "Woensdag")
                    {
                        switch (aPerson.Woensdag)
                        {
                            case 1:
                                mogelijkseheenrijders.Add(aPerson);
                                iedereenDieMeeMoet.Add(aPerson);
                                break;
                            case 2:
                                mogelijkseterugrijders.Add(aPerson);
                                iedereenDieMeeMoet.Add(aPerson);
                                break;
                            case 3:
                                mogelijkseheenrijders.Add(aPerson);
                                mogelijkseterugrijders.Add(aPerson);
                                iedereenDieMeeMoet.Add(aPerson);
                                break;
                            case 4:
                                iedereenDieMeeMoet.Add(aPerson);
                                break;

                        }
                    }
                    if (dag == "Donderdag")
                    {
                        switch (aPerson.Donderdag)
                        {
                            case 1:
                                mogelijkseheenrijders.Add(aPerson);
                                iedereenDieMeeMoet.Add(aPerson);
                                break;
                            case 2:
                                mogelijkseterugrijders.Add(aPerson);
                                iedereenDieMeeMoet.Add(aPerson);
                                break;
                            case 3:
                                mogelijkseheenrijders.Add(aPerson);
                                mogelijkseterugrijders.Add(aPerson);
                                iedereenDieMeeMoet.Add(aPerson);
                                break;
                            case 4:
                                iedereenDieMeeMoet.Add(aPerson);
                                break;

                        }
                    }
                    if (dag == "Vrijdag")
                    {
                        switch (aPerson.Vrijdag)
                        {
                            case 1:
                                mogelijkseheenrijders.Add(aPerson);
                                iedereenDieMeeMoet.Add(aPerson);
                                break;
                            case 2:
                                mogelijkseterugrijders.Add(aPerson);
                                iedereenDieMeeMoet.Add(aPerson);
                                break;
                            case 3:
                                mogelijkseheenrijders.Add(aPerson);
                                mogelijkseterugrijders.Add(aPerson);
                                iedereenDieMeeMoet.Add(aPerson);
                                break;
                            case 4:
                                iedereenDieMeeMoet.Add(aPerson);
                                break;

                        }
                    }
                    if (dag == "Zaterdag")
                    {
                        switch (aPerson.Zaterdag)
                        {
                            case 1:
                                mogelijkseheenrijders.Add(aPerson);
                                iedereenDieMeeMoet.Add(aPerson);
                                break;
                            case 2:
                                mogelijkseterugrijders.Add(aPerson);
                                iedereenDieMeeMoet.Add(aPerson);
                                break;
                            case 3:
                                mogelijkseheenrijders.Add(aPerson);
                                mogelijkseterugrijders.Add(aPerson);
                                iedereenDieMeeMoet.Add(aPerson);
                                break;
                            case 4:
                                iedereenDieMeeMoet.Add(aPerson);
                                break;

                        }
                    }
                    if (dag == "Zondag")
                    {
                        switch (aPerson.Zondag)
                        {
                            case 1:
                                mogelijkseheenrijders.Add(aPerson);
                                iedereenDieMeeMoet.Add(aPerson);
                                break;
                            case 2:
                                mogelijkseterugrijders.Add(aPerson);
                                iedereenDieMeeMoet.Add(aPerson);
                                break;
                            case 3:
                                mogelijkseheenrijders.Add(aPerson);
                                mogelijkseterugrijders.Add(aPerson);
                                iedereenDieMeeMoet.Add(aPerson);
                                break;
                            case 4:
                                iedereenDieMeeMoet.Add(aPerson);
                                break;
                        }
                    }
                }

                if (mogelijkseheenrijders.Count > 0 && mogelijkseterugrijders.Count > 0)
                {//Get the amount of passagiers per auto
                    List<int> PassagiersPerAuto = new List<int>();
                    int intAantalPassagiers = intAantalPersonen - intAantalAutos;
                    int intRestwaarde = intAantalPassagiers % intAantalAutos;
                    for (int intXCounter = 0; intXCounter < intAantalAutos; intXCounter++)
                    {
                        int intX = (intAantalPassagiers - intRestwaarde) / intAantalAutos;
                        if (intRestwaarde > 0)
                        {
                            intRestwaarde--;
                            intX++;
                        }
                        PassagiersPerAuto.Add(intX);
                    }

                    //Loop the date
                    int intLoopDateHeenRijder = 0;
                    int intLoopDateTerugRijder = 1;

                    if (MixBestuurders)
                    {
                        intLoopDateHeenRijder = intStartHeenRijder;
                        if (intStartTerugRijder >= mogelijkseterugrijders.Count)
                        {
                            intStartTerugRijder = 0;
                        }
                        intLoopDateTerugRijder = intStartTerugRijder;
                    }

                    int intLoopDateHeenPassagier = 0;
                    int intLoopDateTerugPassagier = 0;
                    bool EersteKeerP = true;
                    bool EersteKeerB = true;
                    //int intLoopDateHeenRijder = loopt per datum
                    //int intLoopDateTerugRijder = loopt per datum
                    //int intLoopDateHeenPassagier = loopt per datum
                    //int intLoopDateTerugPassagier = loopt per datum
                    for (int intRowCounter = 0; intRowCounter < intAantalRijen; intRowCounter++)
                    { //Voor elke datum...
                        if (EersteKeerB)
                        {
                            if (intLoopDateTerugRijder < (mogelijkseterugrijders.Count - 1))
                            {//Zo laten

                            }
                            else
                            {
                                intLoopDateTerugRijder = 0;
                            }
                            EersteKeerB = false;
                        }

                        //Zet de heenbestuurders en de terugbestuurders die effectief chauffeur spelen in en list
                        var HeenBestuurders = new List<Persoon>();
                        var TerugBestuurders = new List<Persoon>();
                        int intLDHBcounter = intLoopDateHeenRijder;
                        int intLDTBcounter = intLoopDateTerugRijder;
                        for (int intAutocounter = 0; intAutocounter < intAantalAutos; intAutocounter++)
                        {//Voor elke auto...
                         //Heen
                            HeenBestuurders.Add(mogelijkseheenrijders[intLDHBcounter]);
                            if (intLDHBcounter < (mogelijkseheenrijders.Count - 1))
                            {
                                intLDHBcounter++;
                            }
                            else
                            {
                                intLDHBcounter = 0;
                            }

                            //Terug
                            TerugBestuurders.Add(mogelijkseterugrijders[intLDTBcounter]);
                            if (intLDTBcounter < (mogelijkseterugrijders.Count - 1))
                            {
                                intLDTBcounter++;
                            }
                            else
                            {
                                intLDTBcounter = 0;
                            }

                            //Bij laatste
                            if (intAutocounter == (intAantalAutos - 1))
                            {
                                intLoopDateHeenRijder = intLDHBcounter;
                                intLoopDateTerugRijder = intLDTBcounter;
                            }
                        }

                        //Get all heen & terugpassagiers
                        var heenPassagiers = new List<Persoon>();
                        var terugPassagiers = new List<Persoon>();
                        foreach (var persoon in iedereenDieMeeMoet)
                        {
                            if (!HeenBestuurders.Contains(persoon))
                            {
                                heenPassagiers.Add(persoon);
                            }
                            if (!TerugBestuurders.Contains(persoon))
                            {
                                terugPassagiers.Add(persoon);
                            }
                        }


                        if (MixPassagiers)
                        {
                            if (EersteKeerP)
                            {
                                if (intLoopDateTerugPassagier < (terugPassagiers.Count - 1))
                                {
                                    intLoopDateTerugPassagier++;
                                }
                                else
                                {
                                    intLoopDateTerugPassagier = 0;
                                }
                                EersteKeerP = false;
                            }

                            //Maak list van heen en terug passagiers mbv de intLoopDateHeenPassagier & intLoopDateTerugPassagier
                            var mixedheenPassagiers = new List<Persoon>();
                            int intLDHPCounter = intLoopDateHeenPassagier;
                            for (int intXCounter = 0; intXCounter < heenPassagiers.Count; intXCounter++)
                            {
                                mixedheenPassagiers.Add(heenPassagiers[intLDHPCounter]);
                                if (intLDHPCounter < (heenPassagiers.Count - 1))
                                {
                                    intLDHPCounter++;
                                }
                                else
                                {
                                    intLDHPCounter = 0;
                                }
                            }
                            var mixedterugPassagiers = new List<Persoon>();
                            int intLDTPCounter = intLoopDateTerugPassagier;
                            for (int intXCounter = 0; intXCounter < terugPassagiers.Count; intXCounter++)
                            {
                                mixedterugPassagiers.Add(terugPassagiers[intLDTPCounter]);
                                if (intLDTPCounter < (terugPassagiers.Count - 1))
                                {
                                    intLDTPCounter++;
                                }
                                else
                                {
                                    intLDTPCounter = 0;
                                }
                            }

                            heenPassagiers = mixedheenPassagiers;
                            terugPassagiers = mixedterugPassagiers;

                            //Stel begin van passagierslijst in voor volgende datum
                            if (intLoopDateHeenPassagier < (heenPassagiers.Count - 1))
                            {
                                intLoopDateHeenPassagier++;
                            }
                            else
                            {
                                intLoopDateHeenPassagier = 0;
                            }
                            if (intLoopDateTerugPassagier < (terugPassagiers.Count - 1))
                            {
                                intLoopDateTerugPassagier++;
                            }
                            else
                            {
                                intLoopDateTerugPassagier = 0;
                            }
                        }

                        //Verdeel de passagiers gelijk onder de auto's en stel bestuurder in
                        List<Auto> autoLijst = new List<Auto>();
                        int counter = 0;
                        foreach (int amountP in PassagiersPerAuto)
                        {//Voor elke auto
                            //COMBINEREN
                            Auto newAuto = new Auto();
                            Heen newHeen = new Heen();
                            newHeen.Bestuurder = HeenBestuurders[counter].Naam;
                            Terug newTerug = new Terug();
                            newTerug.Bestuurder = TerugBestuurders[counter].Naam;
                            for (int intPCounter = 0; intPCounter < amountP; intPCounter++)
                            {
                                newHeen.Passagiers.Add(heenPassagiers[0].Naam);
                                heenPassagiers.Remove(heenPassagiers[0]);
                                newTerug.Passagiers.Add(terugPassagiers[0].Naam);
                                terugPassagiers.Remove(terugPassagiers[0]);
                            }
                            newAuto.heen = newHeen;
                            newAuto.terug = cbCarsDIfferent.Checked ? newTerug : new Terug()
                            {
                                Bestuurder = newHeen.Bestuurder,
                                Passagiers = newHeen.Passagiers
                            };
                            newAuto.Weekdag = dag;
                            newAuto.AutoNummer = counter + 1;
                            autoLijst.Add(newAuto);
                            counter++;
                        }

                        //Voeg autolijst van deze dag toe aan deze dag
                        WDag newWDag = new WDag();
                        newWDag.Datum = dataLijst[intRowCounter].Date;
                        newWDag.AutoLijst = autoLijst;

                        switch (dag)
                        {
                            case "Maandag":
                                Maandag.Add(newWDag);
                                break;
                            case "Dinsdag":
                                Dinsdag.Add(newWDag);
                                break;
                            case "Woensdag":
                                Woensdag.Add(newWDag);
                                break;
                            case "Donderdag":
                                Donderdag.Add(newWDag);
                                break;
                            case "Vrijdag":
                                Vrijdag.Add(newWDag);
                                break;
                            case "Zaterdag":
                                Zaterdag.Add(newWDag);
                                break;
                            case "Zondag":
                                Zondag.Add(newWDag);
                                break;
                        }

                        if (MixBestuurders)
                        {
                            if (intStartHeenRijder < (mogelijkseheenrijders.Count - 1))
                            {
                                intStartHeenRijder++;
                            }
                            else
                            {
                                intStartHeenRijder = 0;
                            }
                            if (intStartTerugRijder < (mogelijkseterugrijders.Count - 1))
                            {
                                intStartTerugRijder++;
                            }
                            else
                            {
                                intStartTerugRijder = 0;
                            }
                            intLoopDateHeenRijder = intStartHeenRijder;
                            intLoopDateTerugRijder = intStartTerugRijder;
                        }
                    }
                }
            }
            if (IsMogelijk)
            {
                //Voeg elke dag toe aan de totale lijst
                NamenLijstDagDatumAutosHT.Add(Maandag);
                NamenLijstDagDatumAutosHT.Add(Dinsdag);
                NamenLijstDagDatumAutosHT.Add(Woensdag);
                NamenLijstDagDatumAutosHT.Add(Donderdag);
                NamenLijstDagDatumAutosHT.Add(Vrijdag);
                NamenLijstDagDatumAutosHT.Add(Zaterdag);
                NamenLijstDagDatumAutosHT.Add(Zondag);
                //Namen zijn gegenereerd
            }
            else
            {
                lblError.Text = "Met dit maximum aantal passagiers en deze hoeveelheid auto's is het niet mogelijk om een schema te maken.";
            }
        }
        private void SorteerData()
        {
            //Sorteer de data op datum (niet op weekdagen want das veel moeilijker om te gebruiken)
            List<SortDate> sortdatelijst = new List<SortDate>();
            foreach (Datum aDate in dataLijst)
            {
                string[] splitdate = aDate.Date.Split('/');
                SortDate newSortDate = new SortDate();
                newSortDate.Dag = Convert.ToInt32(splitdate[0]);
                newSortDate.Maand = Convert.ToInt32(splitdate[1]);
                newSortDate.Jaar = Convert.ToInt32(splitdate[2]);
                newSortDate.Weekdag = aDate.Weekdag;
                sortdatelijst.Add(newSortDate);
            }
            List<SortDate> newsortdatelijst = sortdatelijst.OrderBy(u => u.Jaar).ThenBy(u => u.Maand).ThenBy(u => u.Dag).ToList();
            dataLijst.Clear();
            foreach (SortDate aSortDate in newsortdatelijst)
            {
                Datum newDate = new Datum();
                newDate.Date = aSortDate.Dag.ToString() + "/" + aSortDate.Maand.ToString() + "/" + aSortDate.Jaar.ToString();
                newDate.Weekdag = aSortDate.Weekdag;
                dataLijst.Add(newDate);
            }
        }
        private void btnSortData_Click(object sender, EventArgs e)
        {
            SorteerData();
            ConvertDataListToDLData();
        }
        private string GenerateStrHeen(int intHT1, int intHT2, int intHT3)
        {
            try
            {
                string strHeen = NamenLijstDagDatumAutosHT[intHT1][intHT2].AutoLijst[intHT3].heen.Bestuurder;

                for (int intC = 0; intC < NamenLijstDagDatumAutosHT[intHT1][intHT2].AutoLijst[intHT3].heen.Passagiers.Count; intC++)
                {
                    if (intC == 0)
                    {
                        strHeen += " (" + NamenLijstDagDatumAutosHT[intHT1][intHT2].AutoLijst[intHT3].heen.Passagiers[0];
                    }
                    if (intC != 0)
                    {
                        strHeen += ", " + NamenLijstDagDatumAutosHT[intHT1][intHT2].AutoLijst[intHT3].heen.Passagiers[intC];
                    }
                    if ((intC + 1) == NamenLijstDagDatumAutosHT[intHT1][intHT2].AutoLijst[intHT3].heen.Passagiers.Count)
                    {
                        strHeen += ")";
                    }
                }

                return strHeen;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return string.Empty;
            }
        }
        private string GenerateStrTerug(int intHT1, int intHT2, int intHT3)
        {
            try
            {
                string strTerug = NamenLijstDagDatumAutosHT[intHT1][intHT2].AutoLijst[intHT3].terug.Bestuurder;

                for (int intC = 0; intC < NamenLijstDagDatumAutosHT[intHT1][intHT2].AutoLijst[intHT3].terug.Passagiers.Count; intC++)
                {
                    if (intC == 0)
                    {
                        strTerug += " (" + NamenLijstDagDatumAutosHT[intHT1][intHT2].AutoLijst[intHT3].terug.Passagiers[0];
                    }
                    if (intC != 0)
                    {
                        strTerug += ", " + NamenLijstDagDatumAutosHT[intHT1][intHT2].AutoLijst[intHT3].terug.Passagiers[intC];
                    }
                    if ((intC + 1) == NamenLijstDagDatumAutosHT[intHT1][intHT2].AutoLijst[intHT3].terug.Passagiers.Count)
                    {
                        strTerug += ")";
                    }
                }

                return strTerug;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return string.Empty;
            }
        }
        #endregion
    }
}
