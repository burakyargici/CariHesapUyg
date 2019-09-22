using CariHesap.DAL;
using CariHesap.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CariHesap.UI
{
    public partial class Dashboard : Form
    {
        private Users activeUser;
        private Customers selectedCustomer;
        private List<Customers> userCustomer;

        private List<ProductModel> productModelList;
        private ProductModel selectedProductModel;

        private Categories selectedCategory;
        private List<Categories> categoryList;


        public Dashboard()
        {
            InitializeComponent();
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var menus = sender as TabControl;
            switch (menus.SelectedIndex)
            {
                case 0:
                    //müşteriler
                    LoadUserCustomers();
                    break;
                case 1:
                    //raporlar
                    break;
                case 2:
                    //satış yönetimi
                    break;
                case 3:
                    //ürün yönetimi
                    LoadUserProducts();
                    break;
                case 4:
                    //kategori yönetimi
                    LoadCategories();
                    break;
                case 5:
                    //kullanıcı ayarları

                    break;
            }
        }
        #region Musteriler             
       
        private void LoadUserCustomers()
        {
            customerListView.Items.Clear();

            userCustomer = CustomerHelper.GetCustomersByUserId(activeUser.userId);

            foreach (var item in userCustomer)
            {
                string[] row = { "",item.customerName, item.customerSurname, item.customerPhone, item.customerAddress };
                var satir = new ListViewItem(row);
                customerListView.Items.Add(satir);
            }
        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            Close();
            
        }

        private void LblKullaniciAdi_Click(object sender, EventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            activeUser = UserHelper.activeUser;
            lblKullaniciAdi.Text = activeUser.userName.ToUpper();

            //ilk açılışta ilk sekmedeki veriler otomatik gelsin otomatik veriler gelsin
            LoadUserCustomers();
        }

        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            var login = new Form1();
            login.Show();
        }

        private void Button1_Click(object sender, EventArgs e)//fill in the gaps for modify
        {
            selectedCustomer = userCustomer[customerListView.SelectedIndices[0]];

            updatedCustomerName.Text = selectedCustomer.customerName;
            updatedCustomerSurname.Text = selectedCustomer.customerSurname;
            updatedCustomerPhone.Text = selectedCustomer.customerPhone;
            updatedCustomerAddress.Text = selectedCustomer.customerAddress;

        }

        private void Button4_Click(object sender, EventArgs e)//modify
        {
            selectedCustomer.customerName = updatedCustomerName.Text;
            selectedCustomer.customerSurname = updatedCustomerSurname.Text;
            selectedCustomer.customerPhone = updatedCustomerPhone.Text;
            selectedCustomer.customerAddress = updatedCustomerAddress.Text;

            CustomerHelper.CustomerCUD(selectedCustomer, System.Data.Entity.EntityState.Modified);
            LoadUserCustomers();
        }

        private void Button13_Click(object sender, EventArgs e)//password changing
        {
            if (newPassLbl2.Text == newPassLbl1.Text && passLbl1.Text == activeUser.userPassword)
            {
                activeUser.userPassword = newPassLbl2.Text;
                //UserHelper.ActiveUser = activeUser;               

                var saveModel = UserHelper.UserCUD(activeUser, System.Data.Entity.EntityState.Modified);
                MessageBox.Show(saveModel.message, "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lütfendeğiştirmek istediğiniz şifreleri doğru giriniz..", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Button2_Click(object sender, EventArgs e)//deleting
        {
            DialogResult dr = MessageBox.Show("Bu işlem geri alınamaz. Yine de silinsin mi?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                selectedCustomer = userCustomer[customerListView.SelectedIndices[0]];
                var saveModel = CustomerHelper.CustomerCUD(selectedCustomer, System.Data.Entity.EntityState.Deleted);
                LoadUserCustomers();
                MessageBox.Show(saveModel.message, "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                LoadUserCustomers();
            }
            
        }

        private void Button3_Click(object sender, EventArgs e)//adding
        {
            Customers customer = new Customers();
            customer.customerName = addedCustomerName.Text;
            customer.customerSurname = addedCustomerSurname.Text;
            customer.customerPhone = addedCustomerPhone.Text;
            customer.customerAddress = addedCustomerAddress.Text;
            customer.userId = activeUser.userId;

            var status = CustomerHelper.CustomerCUD(customer, System.Data.Entity.EntityState.Added);
            LoadUserCustomers();
            MessageBox.Show(status.message);
            
        }
        #endregion
        #region Ürün Yönetimi
        private void LoadUserProducts()
        {
            ProductsListView.Items.Clear();

            productModelList = ProductHelper.GetProducts();

            foreach (var item in productModelList)
            {
                string[] row = { "", item.productName, item.categories.categoryName, item.buyPrice.ToString(), item.sellPrice.ToString(), item.stockCount.ToString(), item.description};
                var satir = new ListViewItem(row);
                ProductsListView.Items.Add(satir);
            }
        }

        private void Button7_Click(object sender, EventArgs e)//deleting
        {
            selectedProductModel = productModelList[ProductsListView.SelectedIndices[0]];
            var deletedProduct = new Products
            {
                productId = selectedProductModel.productId,
                productName = selectedProductModel.productName,
                categoryId = selectedProductModel.categoryId,
                buyPrice = selectedProductModel.buyPrice,
                sellPrice = selectedProductModel.sellPrice,
                stockCount = selectedProductModel.stockCount,
                description = selectedProductModel.description
            };

            ProductHelper.ProductCUD(deletedProduct, System.Data.Entity.EntityState.Deleted);
            LoadUserProducts();
        }

        private void UrunDuzenleBtn_Click(object sender, EventArgs e)
        {
            selectedProductModel = productModelList[ProductsListView.SelectedIndices[0]];

            urunAdiDuzanleTxt.Text = selectedProductModel.productName;
            alisUcretiDuzenleTxt.Text = selectedProductModel.buyPrice.ToString();
            satisUcretiDuzenleTxt.Text = selectedProductModel.sellPrice.ToString();
            stokDuzenleTxt.Text = selectedProductModel.stockCount.ToString();
            aciklamaDuzenleTxt.Text = selectedProductModel.description;
           
            kategoriDuzenleCombo.Items.Add(selectedProductModel.categories.categoryName);
            kategoriDuzenleCombo.SelectedIndex = 0;

            
            
        }

        private void TabPage4_Click(object sender, EventArgs e)
        {

        }

        private void DuzenleBtn_Click(object sender, EventArgs e)
        {
            var ModifiedProduct = new Products
            {
                productName = urunAdiDuzanleTxt.Text,
                buyPrice = Convert.ToInt32(alisUcretiDuzenleTxt.Text),
                sellPrice = Convert.ToInt32(satisUcretiDuzenleTxt.Text),
                stockCount = Convert.ToInt32(stokDuzenleTxt.Text),
                description = aciklamaDuzenleTxt.Text,
                //categoryId = Convert.ToInt32(kategoriDuzenleCombo.SelectedItem)
                categoryId = Convert.ToInt32(CategoryHelper.GetCategoryByName(kategoriDuzenleCombo.SelectedItem.ToString()).categoryId)

            };

            

            ProductHelper.ProductCUD(ModifiedProduct, System.Data.Entity.EntityState.Modified);
            LoadUserProducts();
        }

        

        private void KategoriEkleCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
           selectedCategory = CategoryHelper.GetCategoryByName(kategoriEkleCombo.SelectedItem.ToString());

            
        }

        private void EkleBtn_Click(object sender, EventArgs e)
        {
            var newP = new Products
            {
                categoryId = selectedCategory.categoryId,
                productName = urunAdiEkleTxt.Text,
                buyPrice = Convert.ToInt32(alisUcretEkleTxt.Text),
                sellPrice = Convert.ToInt32(satisUcretiEkleTxt.Text),
                stockCount = Convert.ToInt32(stokEkleTxt.Text),
                description = aciklamaEkleTxt.Text,              
            };

            ProductHelper.ProductCUD(newP, System.Data.Entity.EntityState.Added);
            LoadUserProducts();
        }

        private void UrunAdiEkleTxt_TextChanged(object sender, EventArgs e)
        {
            kategoriEkleCombo.DataSource = CategoryHelper.GetCategories();
        }
        #endregion
        #region Kategori Yönetimi
        private void LoadCategories()
        {
            CategoryListView.Items.Clear();

            categoryList = CategoryHelper.GetCategories();

            foreach (var item in categoryList)
            {
                string[] row = { "", item.categoryName, item.categoryDescription};
                var satir = new ListViewItem(row);
                CategoryListView.Items.Add(satir);
            }           
        }

        #endregion region
    }
}
