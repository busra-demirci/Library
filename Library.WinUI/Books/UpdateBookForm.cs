using Library.DTO;
using Library.Service;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Library.WinUI.Books
{
    public partial class UpdateBookForm : Form
    {
        public UpdateBookForm()
        {
            InitializeComponent();
        }

        private void UpdateBookForm_Load(object sender, EventArgs e)
        {
            using (DefinitionService definitionService = new DefinitionService())
            {
                cbRecordStatus.DataSource = definitionService.GetRecordStatuses();
                cbRecordStatus.DisplayMember = "RecordStatusName";
                cbRecordStatus.ValueMember = "RecordStatusId";

                cbGenres.DataSource = definitionService.GetGenres();
                cbGenres.DisplayMember = "GenreName";
                cbGenres.ValueMember = "GenreId";
            }

            using (BookService bookService = new BookService())
            {
                lbBooks.DataSource = bookService.List();
                lbBooks.DisplayMember = "BookName";
                lbBooks.ValueMember = "BookId";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBookName.Text) ||
               string.IsNullOrEmpty(txtAuthor.Text) ||
               nmQuantity.Value < 1)
            {
                lblSaveStatus.Visible = true;
                lblSaveStatus.Text = "Tüm alanları doldurmanız gerekiyor.";
                lblSaveStatus.ForeColor = Color.Red;
                return;
            }

            using (BookService bookService = new BookService())
            {
                BookDTO book = new BookDTO
                {
                    BookId = Convert.ToInt32(lbBooks.SelectedValue),
                    BookName = txtBookName.Text,
                    GenreId = Convert.ToByte(cbGenres.SelectedValue),
                    Author = txtAuthor.Text,
                    PublishDate = dtpPublishDate.Value,
                    UnitsInStock = Convert.ToInt32(nmQuantity.Value),
                    CreatedDate = Convert.ToDateTime(lblCreatedDate.Text),
                    RecordStatusId = Convert.ToByte(cbRecordStatus.SelectedValue)
                };

                var result = bookService.Update(book);

                lblSaveStatus.Visible = true;
                if (result)
                {
                    lblSaveStatus.Text = "Kitap güncelleme başarılı";
                    lblSaveStatus.ForeColor = Color.Green;
                }
                else
                {
                    lblSaveStatus.Text = "Kitap güncellemesi sırasında bir hata oluştu.";
                    lblSaveStatus.ForeColor = Color.Red;
                }
            }
        }

        private void lbBooks_DoubleClick(object sender, EventArgs e)
        {
            lblSaveStatus.Visible = false;

            using (BookService bookService = new BookService())
            {
                int bookId = Convert.ToInt32(lbBooks.SelectedValue);

                var book = bookService.Get(bookId);

                txtBookName.Text = book.BookName;
                cbGenres.SelectedValue = book.GenreId;
                txtAuthor.Text = book.Author;
                dtpPublishDate.Value = book.PublishDate;
                nmQuantity.Value = book.UnitsInStock;
                cbRecordStatus.SelectedValue = book.RecordStatusId;
                lblCreatedDate.Text = book.CreatedDate.ToShortDateString();
            }
        }
    }
}
