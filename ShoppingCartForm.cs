using Computer_Parts_Store.Services;

namespace Computer_Parts_Store.Forms
{
    public partial class ShoppingCartForm : Form
    {
        public ShoppingCartForm()
        {
            InitializeComponent();
            LoadCartItems();
            UpdateSummary();
        }

        private void LoadCartItems()
        {
            dataGridViewCart.Rows.Clear();

            var cartItems = ShoppingCart.GetItems();

            foreach (var item in cartItems)
            {
                decimal total = item.Product.Price * item.Quantity;
                dataGridViewCart.Rows.Add(
                    item.Product.Name,
                    item.Product.Article,
                    item.Product.Price,
                    item.Quantity,
                    total
                );
            }
        }

        private void UpdateSummary()
        {
            int itemsCount = 0;
            decimal totalPrice = 0;

            foreach (DataGridViewRow row in dataGridViewCart.Rows)
            {
                if (!row.IsNewRow && row.Cells["colQuantity"].Value != null && row.Cells["colTotal"].Value != null)
                {
                    try
                    {
                        itemsCount += Convert.ToInt32(row.Cells["colQuantity"].Value);
                        totalPrice += Convert.ToDecimal(row.Cells["colTotal"].Value);
                    }
                    catch
                    {
                        continue;
                    }
                }
            }

            lblItemsCountValue.Text = itemsCount.ToString();
            lblTotalPriceValue.Text = totalPrice.ToString("F2");
        }

        private void dataGridViewCart_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == dataGridViewCart.Columns["colRemove"]?.Index)
            {
                DialogResult result = MessageBox.Show(
                    "Ви впевнені, що хочете видалити цей товар?",
                    "Підтвердження",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string article = dataGridViewCart.Rows[e.RowIndex].Cells["colArticle"].Value?.ToString();
                    if (!string.IsNullOrEmpty(article))
                    {
                        ShoppingCart.RemoveItem(article);
                        LoadCartItems();
                        UpdateSummary();
                        MessageBox.Show("Товар видалено з кошика", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void dataGridViewCart_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == dataGridViewCart.Columns["colQuantity"]?.Index)
            {
                try
                {
                    DataGridViewRow row = dataGridViewCart.Rows[e.RowIndex];

                    if (row.Cells["colPrice"].Value != null && row.Cells["colQuantity"].Value != null)
                    {
                        decimal price = Convert.ToDecimal(row.Cells["colPrice"].Value);
                        int quantity = Convert.ToInt32(row.Cells["colQuantity"].Value);

                        if (quantity <= 0)
                        {
                            MessageBox.Show("Кількість повинна бути більше 0", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            LoadCartItems();
                            return;
                        }

                        row.Cells["colTotal"].Value = price * quantity;
                        UpdateSummary();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка при оновленні кількості: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCheckout_Click(object? sender, EventArgs e)
        {
            if (dataGridViewCart.Rows.Count == 0 || (dataGridViewCart.Rows.Count == 1 && dataGridViewCart.Rows[0].IsNewRow))
            {
                MessageBox.Show("Кошик порожній!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CheckoutForm checkoutForm = new CheckoutForm();
            checkoutForm.ShowDialog();

            // Оновити кошик після оформлення замовлення
            LoadCartItems();
            UpdateSummary();
        }

        private void btnClearCart_Click(object? sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Ви впевнені, що хочете очистити кошик?",
                "Підтвердження",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                ShoppingCart.Clear();
                LoadCartItems();
                UpdateSummary();
                MessageBox.Show("Кошик очищено", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClose_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        // Метод для оновлення даних при відкритті форми
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            LoadCartItems();
            UpdateSummary();
        }
    }
}