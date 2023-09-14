using sampleProduct.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace sampleProduct
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public readonly ShopDBContext _context;

        public MainWindow(ShopDBContext context)
        {
            InitializeComponent();
            _context = context;
            Load();
            cbCategory.SelectedIndex = 1;
            cbSuplierName.SelectedIndex = 1;
        }

        public void Load() {
            DGVList.ItemsSource = _context.Products.ToList();
            cbSuplierName.ItemsSource = _context.Suppliers.ToList();
            cbCategory.ItemsSource = _context.Categories.ToList();
        }

        public Product getInfo()
        {
            bool aDiscontinued = false;
            var categoryName = cbCategory.Text;
            var supplierName = cbSuplierName.Text;

            int? idCategory = _context.Categories.FirstOrDefault(category => category.CategoryName == categoryName)?.CategoryId;
            int? idSupplier = _context.Suppliers.FirstOrDefault(category => category.CompanyName == supplierName)?.SupplierId;
            if (ckbDiscontinued.IsChecked == true)
            {
                aDiscontinued = true;
            }
            return new Product
            {
                ProductName = txtName.Text,
                SupplierId = idSupplier,
                CategoryId = idCategory,
                QuantityPerUnit = txtQuantity.Text,
                UnitPrice = Decimal.Parse(txtUnitPrice.Text),
                UnitsInStock = Int16.Parse(txtUnitInStock.Text),
                UnitsOnOrder = Int16.Parse(txtUnitOnOder.Text),
                ReorderLevel = Int16.Parse(txtReoderLevel.Text),
                Discontinued = aDiscontinued
            };
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            txtProductID.Text = null;
            cbSuplierName.SelectedItem = null;
               ckbDiscontinued.IsChecked = false;

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var Product = getInfo();
                if (Product != null)
                {
                    _context.Add(Product);
                    _context.SaveChanges();
                    Load();
                    MessageBox.Show("Da them thanh cong" + Product.ToString());
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DGVList_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var aProduct = (sender as DataGrid).SelectedItem;
            if (aProduct != null)
            {
                Models.Product current = (Models.Product) aProduct;
                if (current != null)
                {
                    var cont = current.Discontinued;
                    if (cont)
                    {
                        ckbDiscontinued.IsChecked = true;
                    }
                    else
                    {
                        ckbDiscontinued.IsChecked = false;

                    }
                }
            }
        }
    }
}

