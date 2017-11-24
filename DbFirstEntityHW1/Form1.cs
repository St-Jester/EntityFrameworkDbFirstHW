using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DbFirstEntityHW1
{
    public partial class Form1 : Form
    {
        Database1Entities db;

        public Form1()
        {
            InitializeComponent();
        }

        private void LoadInfoBook()
        {
            var booklist = db.Book.Select(g => new {
                Id = g.Id,
                Title = g.Title,
                IdAuthor = g.IdAuthor,
                IdPublisher = g.IdPublisher
            }).ToList();
            dataGridView3.DataSource = booklist;
        }


        private void LoadInfoAuthor()
        {
            var alist = db.Author.ToList();
            dataGridView2.DataSource = alist;
        }
        private void LoadInfoPub()
        {
            var publist = db.Publisher.ToList();
            dataGridView1.DataSource = publist;
        }

        private void BookAddButton_Click(object sender, EventArgs e)
        {
            Add ad = new Add();
            if (ad.ShowDialog() == DialogResult.OK)
            {
                string t = ad.title;
                Book b = new DbFirstEntityHW1.Book { Title = t, IdAuthor = 1, IdPublisher = 2 };
                db.Book.Add(b);
                db.SaveChanges();

            }
            LoadInfoBook();
        }

        private void BookRemoveButton_Click(object sender, EventArgs e)
        {
            Remove r = new Remove();
            if (r.ShowDialog() == DialogResult.OK)
            {

                var b = db.Book.Where(x => x.Title == r.title).FirstOrDefault();

                if(b !=null)
                {
                    db.Book.Remove(b);
                    db.SaveChanges();
                }
            }
            LoadInfoBook();

        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            LoadInfoBook();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            db = new Database1Entities();
        }

        private void button1_Click(object sender, EventArgs e)//loadAuthor
        {
            LoadInfoAuthor();
        }

        private void button3_Click(object sender, EventArgs e)//add author
        {
            Add ad = new Add();
            if (ad.ShowDialog() == DialogResult.OK)
            {
                string t = ad.title;
                Author a = new Author { AName = t };
                db.Author.Add(a);
                db.SaveChanges();

            }
            LoadInfoAuthor();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Remove r = new Remove();
            if (r.ShowDialog() == DialogResult.OK)
            {

                var b = db.Author.Where(x => x.AName == r.title).FirstOrDefault();

                if (b != null)
                {
                    var bk = db.Book.Where(x => x.Author.AName == b.AName).FirstOrDefault();
                    if (bk == null)
                    {
                        db.Author.Remove(b);
                        db.SaveChanges();
                    }
                    else
                        MessageBox.Show("This author has books!");
                }
            }
            LoadInfoAuthor();

        }

        private void button4_Click(object sender, EventArgs e)//load pub
        {
            LoadInfoPub();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Add ad = new Add();
            if (ad.ShowDialog() == DialogResult.OK)
            {
                string t = ad.title;
                Publisher p = new Publisher { PName = t };
                db.Publisher.Add(p);
                db.SaveChanges();

            }
            LoadInfoPub();
        }

        private void button5_Click(object sender, EventArgs e)//remove pub
        {
            Remove r = new Remove();
            if (r.ShowDialog() == DialogResult.OK)
            {

                var b = db.Publisher.Where(x => x.PName == r.title).FirstOrDefault();

                if (b != null)
                {
                    var bk = db.Book.Where(x => x.Publisher.PName == b.PName).FirstOrDefault();
                    if (bk == null)
                    {
                        db.Publisher.Remove(b);
                        db.SaveChanges();
                    }
                    else
                        MessageBox.Show("This Publisher has books!");

                }
            }
            LoadInfoPub();

        }
    }
}
