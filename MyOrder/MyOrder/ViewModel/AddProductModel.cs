using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MyOrder.Annotations;
using MyOrder.Model;
using Xamarin.Forms;
using Plugin.Media;
using MyOrder.Services;
using MyOrder.View;

namespace MyOrder.ViewModel
{
    public class AddProductModel : INotifyPropertyChanged
    {
        private ProductDetail _productDetail = new ProductDetail();
        ProductServices productServices;
        public string ProductName { get; set; }

        public string ProductCategary { get; set; }

        public string ProductCost { get; set; }

        public byte[] ProductImage { get; set; }
        public string ManufacteringDate { get; set; }
        byte[] bteImageBytes;
        public ImageSource takeImage { get; set; }

        public bool productFlag { get; set; }

        public bool categoryFlag { get; set; }

        public bool costFlag { get; set; }


        public ProductDetail productDetail
        {
            get { return _productDetail; }
            set
            {
                _productDetail = value;
                OnPropertyChanged();
            }
        }
        public AddProductModel()
        {
            productServices = new ProductServices();
        }

        public Command SubmitCommand
        {
            get
            {
                return new Command(() =>
                {
                    //productDetail.ProductImage = bteImageBytes;

                    //    IsBusy = true;
                    //if (customerDetail.Password == "" || customerDetail.CustomerEmailId == "" || customerDetail.CustomerName == "")
                    //{
                    //   message = MessageData.EmptyCredential;
                    //}
                    //else
                    {
                        submitData();
                        Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(
                            new AllProductPage());
                        return;
                    }
                    // IsBusy = false;
                });
            }
        }

        //public Command BrowseCommand
        //{
        //    get
        //    {
        //        return new Command(() =>
        //        {
        //            try
        //            {
        //                await CrossMedia.Current.Initialize();

        //                if (!CrossMedia.Current.IsPickPhotoSupported)
        //                {
        //                    await DisplayAlert("OOps", ":( pic photo not supported.", "OK");
        //                    return;
        //                }
        //                string pathpic = App.getPicturePath;
        //                var file = await CrossMedia.Current.PickPhotoAsync();

        //                if (file == null)
        //                    return;

        //                // await DisplayAlert("File Location", file.Path, "OK");

        //                productDetail.ProductImage = file.Path;
        //                MainImage.Source = ImageSource.FromStream(() =>
        //                {
        //                    var stream = file.GetStream();
        //                    file.Dispose();
        //                    return stream;
        //                });

        //                //or:
        //                //image.Source = ImageSource.FromFile(file.Path);
        //                //image.Dispose();
        //            }
        //            catch { }
        //        });
        //    }
        //}

        public Command TakeCommand
        {
            get
            {
                return new Command(() =>
                {
                    TakePhoto();
                });
            }
        }

        public async void submitData()
        {
            await productServices.postUsersAsync(productDetail);

        }


        public async void TakePhoto()
        {
            try
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    // await DisplayAlert("No Camera", ":( No camera available.", "OK");
                    return;
                }
                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    //Directory = "@" + pathpic,
                    Name = "pic.jpg"

                });


                if (file == null)
                    return;


                // await DisplayAlert("File Location", file.Path, "OK");
                Stream sm = null; Stream sm1 = null;
              
                sm1 = file.GetStream();
                sm = file.GetStream();


                takeImage = ImageSource.FromFile(file.Path);
                BinaryReader br = new BinaryReader(sm);
                bteImageBytes = br.ReadBytes((int)sm.Length);
                productDetail.ProductImage = bteImageBytes;



            }
            catch { }

        }

     

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
