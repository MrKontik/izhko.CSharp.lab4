using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace lab8
{ 
    public partial class Form1 : Form
    {
        string path = "12.xml";
        XDocument xdoc;
        public Form1()
        {
            InitializeComponent();
            readAllRow(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            readFilter();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (checkName(textBox1.Text))
            {
                button3.Enabled = true;
            }
            else
            {
                button3.Enabled = false;
            }
            
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            readAllRow();
        }
        public void readFilter()
        {
            label1.Text = "";
            label8.Text = "";
            label9.Text = "";
            label10.Text = "";
            label11.Text = "";
            label12.Text = "";
            label13.Text = "";
            label14.Text = "";
            label15.Text = "";
            xdoc = XDocument.Load(path);
            var items = from xe in xdoc.Element("subscribers").Elements("subscriber")
                        where xe.Attribute("name").Value == textBox1.Text
                        where xe.Element("district").Value == textBox2.Text
                        where xe.Element("date_conclusion_contract").Value == textBox3.Text
                        where xe.Element("last_payment_date").Value == textBox4.Text
                        select new Subscriber
                        {
                            Name = xe.Attribute("name").Value,
                            District = xe.Element("district").Value,
                            Address = xe.Element("address").Value,
                            Telephone = xe.Element("telephone").Value,
                            Contract = xe.Element("contract").Value,
                            Date_conclusion_contract = xe.Element("date_conclusion_contract").Value,
                            Payment_for_installation = xe.Element("payment_for_installation").Value,
                            Monthly_fee = xe.Element("monthly_fee").Value,
                            Last_payment_date = xe.Element("last_payment_date").Value

                        };
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Name} - {item.District}");
                label1.Text += item.Name + "\n";
                label8.Text += item.District + "\n";
                label9.Text += item.Address + "\n";
                label10.Text += item.Telephone + "\n";
                label11.Text += item.Contract + "\n";
                label12.Text += item.Date_conclusion_contract + "\n";
                label13.Text += item.Payment_for_installation + "\n";
                label14.Text += item.Monthly_fee + "\n";
                label15.Text += item.Last_payment_date + "\n";
            }
        }
        public void readAllRow()
        {
            xdoc = XDocument.Load(path);
            label1.Text = "";
            label8.Text = "";
            label9.Text = "";
            label10.Text = "";
            label11.Text = "";
            label12.Text = "";
            label13.Text = "";
            label14.Text = "";
            label15.Text = "";

            foreach (XElement subscriberElement in xdoc.Element("subscribers").Elements("subscriber"))
            {
                XAttribute nameAttribute = subscriberElement.Attribute("name");
                XElement districtElement = subscriberElement.Element("district");
                XElement addressElement = subscriberElement.Element("address");
                XElement telephoneElement = subscriberElement.Element("telephone");
                XElement contractElement = subscriberElement.Element("contract");
                XElement date_conclusion_contractElement = subscriberElement.Element("date_conclusion_contract");
                XElement payment_for_installationElement = subscriberElement.Element("payment_for_installation");
                XElement monthly_feeElement = subscriberElement.Element("monthly_fee");
                XElement last_payment_dateElement = subscriberElement.Element("last_payment_date");
                if (nameAttribute != null && districtElement != null && addressElement != null && telephoneElement != null && contractElement != null && date_conclusion_contractElement != null
                    && payment_for_installationElement != null && monthly_feeElement != null && last_payment_dateElement != null)
                {
                    label1.Text += nameAttribute.Value + "\n";
                    label8.Text += districtElement.Value + "\n";
                    label9.Text += addressElement.Value + "\n";
                    label10.Text += telephoneElement.Value + "\n";
                    label11.Text += contractElement.Value + "\n";
                    label12.Text += date_conclusion_contractElement.Value + "\n";
                    label13.Text += payment_for_installationElement.Value + "\n";
                    label14.Text += monthly_feeElement.Value + "\n";
                    label15.Text += last_payment_dateElement.Value + "\n";
                }
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddRow();
            readAllRow();
        }

        public void AddRow()
        {
            if (checkName(textBox1.Text) && checkTelephone(textBox6.Text)&& checkOnlyNumber(textBox7.Text)&& checkDate(textBox3.Text) && checkDate(textBox4.Text)
                && checkOnlyNumber(textBox8.Text) && checkOnlyNumber(textBox9.Text))
            { 
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(path);
                XmlElement xRoot = xDoc.DocumentElement;
                // создаем новый элемент user
                XmlElement subscriberElem = xDoc.CreateElement("subscriber");
                // создаем атрибут name
                XmlAttribute nameAttr = xDoc.CreateAttribute("name");
                // создаем элементы company и age
                XmlElement districtElem = xDoc.CreateElement("district");
                XmlElement addressElem = xDoc.CreateElement("address");
                XmlElement telephoneElem = xDoc.CreateElement("telephone");
                XmlElement contractElem = xDoc.CreateElement("contract");
                XmlElement date_conclusion_contractElem = xDoc.CreateElement("date_conclusion_contract");
                XmlElement payment_for_installationElem = xDoc.CreateElement("payment_for_installation");
                XmlElement monthly_feeElem = xDoc.CreateElement("monthly_fee");
                XmlElement last_payment_dateElem = xDoc.CreateElement("last_payment_date");
                // создаем текстовые значения для элементов и атрибута
                XmlText nameText = xDoc.CreateTextNode(textBox1.Text);
                XmlText districtText = xDoc.CreateTextNode(textBox2.Text);
                XmlText addressText = xDoc.CreateTextNode(textBox5.Text);
                XmlText telephoneText = xDoc.CreateTextNode(textBox6.Text);
                XmlText contractText = xDoc.CreateTextNode(textBox7.Text);
                XmlText date_conclusion_contractText = xDoc.CreateTextNode(textBox3.Text);
                XmlText payment_for_installationText = xDoc.CreateTextNode(textBox8.Text);
                XmlText monthly_feeText = xDoc.CreateTextNode(textBox9.Text);
                XmlText last_payment_dateText = xDoc.CreateTextNode(textBox4.Text);
                //добавляем узлы
                nameAttr.AppendChild(nameText);
                districtElem.AppendChild(districtText);
                addressElem.AppendChild(addressText);
                telephoneElem.AppendChild(telephoneText);
                contractElem.AppendChild(contractText);
                date_conclusion_contractElem.AppendChild(date_conclusion_contractText);
                payment_for_installationElem.AppendChild(payment_for_installationText);
                monthly_feeElem.AppendChild(monthly_feeText);
                last_payment_dateElem.AppendChild(last_payment_dateText);

                subscriberElem.Attributes.Append(nameAttr);
                subscriberElem.AppendChild(districtElem);
                subscriberElem.AppendChild(addressElem);
                subscriberElem.AppendChild(telephoneElem);
                subscriberElem.AppendChild(contractElem);
                subscriberElem.AppendChild(date_conclusion_contractElem);
                subscriberElem.AppendChild(payment_for_installationElem);
                subscriberElem.AppendChild(monthly_feeElem);
                subscriberElem.AppendChild(last_payment_dateElem);

                xRoot.AppendChild(subscriberElem);
                xDoc.Save(path);
            }
        }
        public bool checkName(string inp)
        {
            if (Regex.IsMatch(inp, @"^\D+$"))
            {
                return true;
            }
            return false;
        }
        public bool checkTelephone(string inp)
        {
            if (Regex.IsMatch(inp, @"(^\d+$)|(^\+\d+$)"))
            {
                return true;
            }
            return false;
        }
        public bool checkOnlyNumber(string inp)
        {
            if (Regex.IsMatch(inp, @"^\d+$"))
            {
                return true;
            }
            return false;
        }
        public bool checkDate(string inp)
        {
            if (Regex.IsMatch(inp, @"^\d{2}[.:]\d{2}[.:]\d{4}$"))
            {
                return true;
            }
            return false;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                removeRow();
                readAllRow();
            }
            catch
            {
                MessageBox.Show("Такого элемента не существует");
            }
            
        }
        public void removeRow()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            XmlElement xRoot = xDoc.DocumentElement;
            XmlNode childnode = xRoot.SelectSingleNode("subscriber[@name='"+textBox1.Text+"']");
            xRoot.RemoveChild(childnode);
            xDoc.Save(path);
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }

    class Subscriber
    {
        public string Name { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Contract { get; set; }
        public string Date_conclusion_contract { get; set; }
        public string Payment_for_installation { get; set; }
        public string Monthly_fee { get; set; }
        public string Last_payment_date { get; set; }

    }
}
