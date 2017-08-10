using Dropbox.Api;
using Dropbox.Api.Files;
using Newtonsoft.Json;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Mobile.Controls;
using Talent.Mobile.CustomRenderer;
using Talent.Mobile.Models;
using Talent.Mobile.Models.Models;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using System.Net;
using Talent.Mobile.Interface;
using Talent.Mobile.Context;
using Talent.Mobile.Common;

namespace Talent.Mobile.Pages.User
{
    class UploadDocuments : BasePage
    {
        public UploadDocuments()
        {
            UploadDocumentsLayout();
        }
        #region save images
        public static Task<bool> ImageSave(System.IO.Stream fileStream, string userId, string documentType)
        {
            var response = new TaskCompletionSource<bool>();
            string attachmentName = userId + "_" + documentType + ".jpg";
            DocumentModel documentModel = new DocumentModel();
            documentModel.UserId = int.Parse(userId);
            documentModel.AttachmentType = 1;
            documentModel.Attachment = attachmentName;

            Device.BeginInvokeOnMainThread(async () =>
            {
                try
                {
                    System.IO.Stream profilePic = fileStream /* Take a picture */;
                    //var dbx = new DropboxClient("Hc5wwumhyiYAAAAAAAAKDR_FZydsM9in5_-32azCquClRuXfaaS_L6hGrJ7cNguW");
                    var dbx = Constant.dropboxClient;
                    var full = await dbx.Users.GetCurrentAccountAsync();
                    await Upload(dbx, attachmentName, fileStream);


                    response.SetResult(true);

                    var result = await Service.PostDocument(documentModel);
                    
                }
                catch (Exception ex)
                {
                }
            });
            return response.Task;
        }
        #endregion
         
        #region upload files
        public static async Task Upload(DropboxClient dbx, string file, System.IO.Stream content)
        {
            await dbx.Files.UploadAsync("/" + file, WriteMode.Overwrite.Instance, body: content);
        }
        #endregion

        #region download files
        public static Task<System.IO.Stream> Download(string file)
        {
            var response = new TaskCompletionSource<System.IO.Stream>();
            Device.BeginInvokeOnMainThread(async () =>
            {
                //var dbx = new DropboxClient("Hc5wwumhyiYAAAAAAAAKDR_FZydsM9in5_-32azCquClRuXfaaS_L6hGrJ7cNguW");
                var dbx = Constant.dropboxClient;
                using (var fileReponse = await dbx.Files.DownloadAsync("/" + file))
                {
                    var imgProfile = await fileReponse.GetContentAsStreamAsync();
                    response.SetResult(imgProfile);
                }
            });
            return response.Task;
        }
        #endregion

        #region file read method
        public static byte[] ReadFully(System.IO.Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
        #endregion
        
        public void UploadDocumentsLayout()
        {
            if (ACTContext.isLogin == true)
            {
                #region separator
                BoxView separator1 = new BoxView() { Color = Color.Gray, HeightRequest = 1, HorizontalOptions = LayoutOptions.FillAndExpand };
                StackLayout sSeparator1 = new StackLayout
                {
                    Children = { separator1 },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 0)
                };
                BoxView separator2 = new BoxView() { Color = Color.Gray, HeightRequest = 1, HorizontalOptions = LayoutOptions.FillAndExpand };
                StackLayout sSeparator2 = new StackLayout
                {
                    Children = { separator2 },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 0)
                };
                BoxView separator3 = new BoxView() { Color = Color.Gray, HeightRequest = 1, HorizontalOptions = LayoutOptions.FillAndExpand };
                StackLayout sSeparator3 = new StackLayout
                {
                    Children = { separator3 },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 0)
                };
                BoxView separator4 = new BoxView() { Color = Color.Gray, HeightRequest = 1, HorizontalOptions = LayoutOptions.FillAndExpand };
                StackLayout sSeparator4 = new StackLayout
                {
                    Children = { separator4 },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 0)
                };
                BoxView separator5 = new BoxView() { Color = Color.Gray, HeightRequest = 1, HorizontalOptions = LayoutOptions.FillAndExpand };
                StackLayout sSeparator5 = new StackLayout
                {
                    Children = { separator5 },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 0)
                };
                BoxView separator6 = new BoxView() { Color = Color.Gray, HeightRequest = 1, HorizontalOptions = LayoutOptions.FillAndExpand };
                StackLayout sSeparator6 = new StackLayout
                {
                    Children = { separator6 },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 0)
                };
                #endregion

                #region slblUploadDocInfo
                Label lblUploadDocInfo = new Label { Text = "Upload and Download Documents", HorizontalOptions = LayoutOptions.CenterAndExpand, TextColor = Color.FromHex("5e247f"), FontSize = 18, FontAttributes = FontAttributes.Bold, HeightRequest = 30 };
                StackLayout slblUploadDocInfo = new StackLayout
                {
                    Children = { lblUploadDocInfo },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 30, 0, 20)
                };
                #endregion

                #region experience certificate
                Label lblExperienceCertificate = new Label { Text = "Experience Certificate", HorizontalOptions = LayoutOptions.Start, TextColor = Color.Black, WidthRequest = 200 };
                StackLayout slblExperienceCertificate = new StackLayout
                {
                    Children = { lblExperienceCertificate },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 10, 0, 0)
                };
                Button btnExperienceCertificateUpload = new Button { WidthRequest = 40, Image = "upload2.png", Text = "", HorizontalOptions = LayoutOptions.Fill, BackgroundColor = Color.Transparent, TextColor = Color.FromHex("4690FB"), FontAttributes = FontAttributes.None };
                Button btnExperienceCertificateDownload = new Button { WidthRequest = 40, Image = "download2.png", Text = "", HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Transparent, TextColor = Color.FromHex("4690FB"), FontAttributes = FontAttributes.None };
                Button btnExperienceCertificateAdd = new Button { WidthRequest = 40, Image = "add.png", Text = "", HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Transparent, TextColor = Color.FromHex("4690FB"), FontAttributes = FontAttributes.None };
                StackLayout sExperienceCertificate = new StackLayout
                {
                    Children = { slblExperienceCertificate, btnExperienceCertificateUpload, btnExperienceCertificateDownload, btnExperienceCertificateAdd },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 8)
                };
                #endregion

                #region experience certificate2
                Label lblExperienceCertificate2 = new Label { Text = "Experience Certificate", HorizontalOptions = LayoutOptions.Start, TextColor = Color.Black, WidthRequest = 200 };
                StackLayout slblExperienceCertificate2 = new StackLayout
                {
                    Children = { lblExperienceCertificate2 },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 10, 0, 0)
                };
                Button btnExperienceCertificateUpload2 = new Button { WidthRequest = 40, Image = "upload2.png", Text = "", HorizontalOptions = LayoutOptions.Fill, BackgroundColor = Color.Transparent, TextColor = Color.FromHex("4690FB"), FontAttributes = FontAttributes.None };
                Button btnExperienceCertificateDownload2 = new Button { WidthRequest = 40, Image = "download2.png", Text = "", HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Transparent, TextColor = Color.FromHex("4690FB"), FontAttributes = FontAttributes.None };
                Button btnExperienceCertificateRemove2 = new Button { WidthRequest = 40, Image = "remove.png", Text = "", HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Transparent, TextColor = Color.FromHex("4690FB"), FontAttributes = FontAttributes.None };
                StackLayout sExperienceCertificate2 = new StackLayout
                {
                    Children = { slblExperienceCertificate2, btnExperienceCertificateUpload2, btnExperienceCertificateDownload2, btnExperienceCertificateRemove2 },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 8)
                };
                #endregion

                #region experience certificate3
                Label lblExperienceCertificate3 = new Label { Text = "Experience Certificate", HorizontalOptions = LayoutOptions.Start, TextColor = Color.Black, WidthRequest = 200 };
                StackLayout slblExperienceCertificate3 = new StackLayout
                {
                    Children = { lblExperienceCertificate3 },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 10, 0, 0)
                };
                Button btnExperienceCertificateUpload3 = new Button { WidthRequest = 40, Image = "upload2.png", Text = "", HorizontalOptions = LayoutOptions.Fill, BackgroundColor = Color.Transparent, TextColor = Color.FromHex("4690FB"), FontAttributes = FontAttributes.None };
                Button btnExperienceCertificateDownload3 = new Button { WidthRequest = 40, Image = "download2.png", Text = "", HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Transparent, TextColor = Color.FromHex("4690FB"), FontAttributes = FontAttributes.None };
                Button btnExperienceCertificateRemove3 = new Button { WidthRequest = 40, Image = "remove.png", Text = "", HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Transparent, TextColor = Color.FromHex("4690FB"), FontAttributes = FontAttributes.None };
                StackLayout sExperienceCertificate3 = new StackLayout
                {
                    Children = { slblExperienceCertificate3, btnExperienceCertificateUpload3, btnExperienceCertificateDownload3, btnExperienceCertificateRemove3 },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 8)
                };
                #endregion

                #region experience certificate4
                Label lblExperienceCertificate4 = new Label { Text = "Experience Certificate", HorizontalOptions = LayoutOptions.Start, TextColor = Color.Black, WidthRequest = 200 };
                StackLayout slblExperienceCertificate4 = new StackLayout
                {
                    Children = { lblExperienceCertificate4 },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 10, 0, 0)
                };
                Button btnExperienceCertificateUpload4 = new Button { WidthRequest = 40, Image = "upload2.png", Text = "", HorizontalOptions = LayoutOptions.Fill, BackgroundColor = Color.Transparent, TextColor = Color.FromHex("4690FB"), FontAttributes = FontAttributes.None };
                Button btnExperienceCertificateDownload4 = new Button { WidthRequest = 40, Image = "download2.png", Text = "", HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Transparent, TextColor = Color.FromHex("4690FB"), FontAttributes = FontAttributes.None };
                Button btnExperienceCertificateRemove4 = new Button { WidthRequest = 40, Image = "remove.png", Text = "", HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Transparent, TextColor = Color.FromHex("4690FB"), FontAttributes = FontAttributes.None };
                StackLayout sExperienceCertificate4 = new StackLayout
                {
                    Children = { slblExperienceCertificate4, btnExperienceCertificateUpload4, btnExperienceCertificateDownload4, btnExperienceCertificateRemove4 },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 8)
                };
                #endregion

                #region educational qualification
                Label lblEducationalQualification = new Label { Text = "Educational Qualification", HorizontalOptions = LayoutOptions.Start, TextColor = Color.Black, WidthRequest = 200 };
                StackLayout slblEducationalQualification = new StackLayout
                {
                    Children = { lblEducationalQualification },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 10, 0, 0)
                };
                Button btnEducationalQualificationUpload = new Button { WidthRequest = 40, Image = "upload2.png", Text = "", HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Transparent, TextColor = Color.FromHex("4690FB"), FontAttributes = FontAttributes.None };
                Button btnEducationalQualificationDownload = new Button { WidthRequest = 40, Image = "download2.png", Text = "", HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Transparent, TextColor = Color.FromHex("4690FB"), FontAttributes = FontAttributes.None };
                Button btnEducationalQualificationAdd = new Button { WidthRequest = 40, Image = "add.png", Text = "", HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Transparent, TextColor = Color.FromHex("4690FB"), FontAttributes = FontAttributes.None };
                StackLayout sEducationalQualification = new StackLayout
                {
                    Children = { slblEducationalQualification, btnEducationalQualificationUpload, btnEducationalQualificationDownload, btnEducationalQualificationAdd },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 8)
                };
                #endregion

                #region educational qualification2
                Label lblEducationalQualification2 = new Label { Text = "Educational Qualification", HorizontalOptions = LayoutOptions.Start, TextColor = Color.Black, WidthRequest = 200 };
                StackLayout slblEducationalQualification2 = new StackLayout
                {
                    Children = { lblEducationalQualification2 },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 10, 0, 0)
                };
                Button btnEducationalQualificationUpload2 = new Button { WidthRequest = 40, Image = "upload2.png", Text = "", HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Transparent, TextColor = Color.FromHex("4690FB"), FontAttributes = FontAttributes.None };
                Button btnEducationalQualificationDownload2 = new Button { WidthRequest = 40, Image = "download2.png", Text = "", HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Transparent, TextColor = Color.FromHex("4690FB"), FontAttributes = FontAttributes.None };
                Button btnEducationalQualificationRemove2 = new Button { WidthRequest = 40, Image = "remove.png", Text = "", HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Transparent, TextColor = Color.FromHex("4690FB"), FontAttributes = FontAttributes.None };
                StackLayout sEducationalQualification2 = new StackLayout
                {
                    Children = { slblEducationalQualification2, btnEducationalQualificationUpload2, btnEducationalQualificationDownload2, btnEducationalQualificationRemove2 },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 8)
                };
                #endregion

                #region educational qualification3
                Label lblEducationalQualification3 = new Label { Text = "Educational Qualification", HorizontalOptions = LayoutOptions.Start, TextColor = Color.Black, WidthRequest = 200 };
                StackLayout slblEducationalQualification3 = new StackLayout
                {
                    Children = { lblEducationalQualification3 },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 10, 0, 0)
                };
                Button btnEducationalQualificationUpload3 = new Button { WidthRequest = 40, Image = "upload2.png", Text = "", HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Transparent, TextColor = Color.FromHex("4690FB"), FontAttributes = FontAttributes.None };
                Button btnEducationalQualificationDownload3 = new Button { WidthRequest = 40, Image = "download2.png", Text = "", HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Transparent, TextColor = Color.FromHex("4690FB"), FontAttributes = FontAttributes.None };
                Button btnEducationalQualificationRemove3 = new Button { WidthRequest = 40, Image = "remove.png", Text = "", HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Transparent, TextColor = Color.FromHex("4690FB"), FontAttributes = FontAttributes.None };
                StackLayout sEducationalQualification3 = new StackLayout
                {
                    Children = { slblEducationalQualification3, btnEducationalQualificationUpload3, btnEducationalQualificationDownload3, btnEducationalQualificationRemove3 },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 8)
                };
                #endregion

                #region educational qualification4
                Label lblEducationalQualification4 = new Label { Text = "Educational Qualification", HorizontalOptions = LayoutOptions.Start, TextColor = Color.Black, WidthRequest = 200 };
                StackLayout slblEducationalQualification4 = new StackLayout
                {
                    Children = { lblEducationalQualification4 },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 10, 0, 0)
                };
                Button btnEducationalQualificationUpload4 = new Button { WidthRequest = 40, Image = "upload2.png", Text = "", HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Transparent, TextColor = Color.FromHex("4690FB"), FontAttributes = FontAttributes.None };
                Button btnEducationalQualificationDownload4 = new Button { WidthRequest = 40, Image = "download2.png", Text = "", HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Transparent, TextColor = Color.FromHex("4690FB"), FontAttributes = FontAttributes.None };
                Button btnEducationalQualificationRemove4 = new Button { WidthRequest = 40, Image = "remove.png", Text = "", HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Transparent, TextColor = Color.FromHex("4690FB"), FontAttributes = FontAttributes.None };
                StackLayout sEducationalQualification4 = new StackLayout
                {
                    Children = { slblEducationalQualification4, btnEducationalQualificationUpload4, btnEducationalQualificationDownload4, btnEducationalQualificationRemove4 },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 8)
                };
                #endregion

                #region marks card
                Label lblMarksCard = new Label { Text = "Marks Card", HorizontalOptions = LayoutOptions.Start, TextColor = Color.Black, WidthRequest = 200 };
                StackLayout slblMarksCard = new StackLayout
                {
                    Children = { lblMarksCard },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 10, 0, 0)
                };
                Button btnMarksCardUpload = new Button { WidthRequest = 40, Image = "upload2.png", Text = "", HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Transparent, TextColor = Color.FromHex("4690FB"), FontAttributes = FontAttributes.None };
                Button btnMarksCardDownload = new Button { WidthRequest = 40, Image = "download2.png", Text = "", HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Transparent, TextColor = Color.FromHex("4690FB"), FontAttributes = FontAttributes.None };
                Button btnMarksCardAdd = new Button { WidthRequest = 40, Image = "add.png", Text = "", HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Transparent, TextColor = Color.FromHex("4690FB"), FontAttributes = FontAttributes.None };
                StackLayout sMarksCard = new StackLayout
                {
                    Children = { slblMarksCard, btnMarksCardUpload, btnMarksCardDownload, btnMarksCardAdd },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 8)
                };
                #endregion

                #region marks card2
                Label lblMarksCard2 = new Label { Text = "Marks Card", HorizontalOptions = LayoutOptions.Start, TextColor = Color.Black, WidthRequest = 200 };
                StackLayout slblMarksCard2 = new StackLayout
                {
                    Children = { lblMarksCard2 },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 10, 0, 0)
                };
                Button btnMarksCardUpload2 = new Button { WidthRequest = 40, Image = "upload2.png", Text = "", HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Transparent, TextColor = Color.FromHex("4690FB"), FontAttributes = FontAttributes.None };
                Button btnMarksCardDownload2 = new Button { WidthRequest = 40, Image = "download2.png", Text = "", HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Transparent, TextColor = Color.FromHex("4690FB"), FontAttributes = FontAttributes.None };
                Button btnMarksCardRemove2 = new Button { WidthRequest = 40, Image = "remove.png", Text = "", HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Transparent, TextColor = Color.FromHex("4690FB"), FontAttributes = FontAttributes.None };
                StackLayout sMarksCard2 = new StackLayout
                {
                    Children = { slblMarksCard2, btnMarksCardUpload2, btnMarksCardDownload2, btnMarksCardRemove2 },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 8)
                };
                #endregion

                #region marks card3
                Label lblMarksCard3 = new Label { Text = "Marks Card", HorizontalOptions = LayoutOptions.Start, TextColor = Color.Black, WidthRequest = 200 };
                StackLayout slblMarksCard3 = new StackLayout
                {
                    Children = { lblMarksCard3 },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 10, 0, 0)
                };
                Button btnMarksCardUpload3 = new Button { WidthRequest = 40, Image = "upload2.png", Text = "", HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Transparent, TextColor = Color.FromHex("4690FB"), FontAttributes = FontAttributes.None };
                Button btnMarksCardDownload3 = new Button { WidthRequest = 40, Image = "download2.png", Text = "", HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Transparent, TextColor = Color.FromHex("4690FB"), FontAttributes = FontAttributes.None };
                Button btnMarksCardRemove3 = new Button { WidthRequest = 40, Image = "remove.png", Text = "", HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Transparent, TextColor = Color.FromHex("4690FB"), FontAttributes = FontAttributes.None };
                StackLayout sMarksCard3 = new StackLayout
                {
                    Children = { slblMarksCard3, btnMarksCardUpload3, btnMarksCardDownload3, btnMarksCardRemove3 },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 8)
                };
                #endregion

                #region marks card4
                Label lblMarksCard4 = new Label { Text = "Marks Card", HorizontalOptions = LayoutOptions.Start, TextColor = Color.Black, WidthRequest = 200 };
                StackLayout slblMarksCard4 = new StackLayout
                {
                    Children = { lblMarksCard4 },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 10, 0, 0)
                };
                Button btnMarksCardUpload4 = new Button { WidthRequest = 40, Image = "upload2.png", Text = "", HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Transparent, TextColor = Color.FromHex("4690FB"), FontAttributes = FontAttributes.None };
                Button btnMarksCardDownload4 = new Button { WidthRequest = 40, Image = "download2.png", Text = "", HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Transparent, TextColor = Color.FromHex("4690FB"), FontAttributes = FontAttributes.None };
                Button btnMarksCardRemove4 = new Button { WidthRequest = 40, Image = "remove.png", Text = "", HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Transparent, TextColor = Color.FromHex("4690FB"), FontAttributes = FontAttributes.None };
                StackLayout sMarksCard4 = new StackLayout
                {
                    Children = { slblMarksCard4, btnMarksCardUpload4, btnMarksCardDownload4, btnMarksCardRemove4 },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 8)
                };
                #endregion

                #region pan card
                Label lblPanCard = new Label { Text = "Pan Card", HorizontalOptions = LayoutOptions.Start, TextColor = Color.Black, WidthRequest = 200 };
                StackLayout slblPanCard = new StackLayout
                {
                    Children = { lblPanCard },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 10, 0, 0)
                };
                Button btnPanCardUpload = new Button { WidthRequest = 40, Image = "upload2.png", Text = "", HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Transparent, TextColor = Color.FromHex("4690FB"), FontAttributes = FontAttributes.None };
                Button btnPanCardDownload = new Button { WidthRequest = 40, Image = "download2.png", Text = "", HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Transparent, TextColor = Color.FromHex("4690FB"), FontAttributes = FontAttributes.None };
                Button btnTemp = new Button { WidthRequest = 40, Text = "", HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Transparent, TextColor = Color.FromHex("4690FB"), FontAttributes = FontAttributes.None };
                StackLayout sPanCard = new StackLayout
                {
                    Children = { slblPanCard, btnPanCardUpload, btnPanCardDownload, btnTemp },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 8)
                };
                #endregion

                #region aadhar card
                Label lblAadharCard = new Label { Text = "Aadhar Card", HorizontalOptions = LayoutOptions.Start, TextColor = Color.Black, WidthRequest = 200 };
                StackLayout slblAadharCard = new StackLayout
                {
                    Children = { lblAadharCard },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 10, 0, 0)
                };
                Button btnAadharCardUpload = new Button { WidthRequest = 40, Image = "upload2.png", Text = "", HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Transparent, TextColor = Color.FromHex("4690FB"), FontAttributes = FontAttributes.None };
                Button btnAadharCardDownload = new Button { WidthRequest = 40, Image = "download2.png", Text = "", HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Transparent, TextColor = Color.FromHex("4690FB"), FontAttributes = FontAttributes.None };
                Button btnTemp0 = new Button { WidthRequest = 40, Text = "", HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Transparent, TextColor = Color.FromHex("4690FB"), FontAttributes = FontAttributes.None };
                StackLayout sAadharCard = new StackLayout
                {
                    Children = { slblAadharCard, btnAadharCardUpload, btnAadharCardDownload, btnTemp0 },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 8)
                };
                #endregion

                #region passport
                Label lblPassport = new Label { Text = "Passport", HorizontalOptions = LayoutOptions.Start, TextColor = Color.Black, WidthRequest = 200 };
                StackLayout slblPassport = new StackLayout
                {
                    Children = { lblPassport },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 10, 0, 0)
                };
                Button btnPassportUpload = new Button { WidthRequest = 40, Image = "upload2.png", Text = "", HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Transparent, TextColor = Color.FromHex("4690FB"), FontAttributes = FontAttributes.None };
                Button btnPassportDownload = new Button { WidthRequest = 40, Image = "download2.png", Text = "", HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Transparent, TextColor = Color.FromHex("4690FB"), FontAttributes = FontAttributes.None };
                Button btnTemp1 = new Button { WidthRequest = 40, Text = "", HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Transparent, TextColor = Color.FromHex("4690FB"), FontAttributes = FontAttributes.None };
                StackLayout sPassport = new StackLayout
                {
                    Children = { slblPassport, btnPassportUpload, btnPassportDownload, btnTemp1 },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 8)
                };
                #endregion

                #region driving license
                Label lblDrivingLicense = new Label { Text = "Driving License", HorizontalOptions = LayoutOptions.Start, TextColor = Color.Black, WidthRequest = 200 };
                StackLayout slblDrivingLicense = new StackLayout
                {
                    Children = { lblDrivingLicense },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 10, 0, 0)
                };
                Button btnDrivingLicenseUpload = new Button { WidthRequest = 40, Image = "upload2.png", Text = "", HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Transparent, TextColor = Color.FromHex("4690FB"), FontAttributes = FontAttributes.None };
                Button btnDrivingLicenseDownload = new Button { WidthRequest = 40, Image = "download2.png", Text = "", HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Transparent, TextColor = Color.FromHex("4690FB"), FontAttributes = FontAttributes.None };
                Button btnTemp2 = new Button { WidthRequest = 40, Text = "", HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Transparent, TextColor = Color.FromHex("4690FB"), FontAttributes = FontAttributes.None };
                StackLayout sDrivingLicense = new StackLayout
                {
                    Children = { slblDrivingLicense, btnDrivingLicenseUpload, btnDrivingLicenseDownload, btnTemp2 },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 8)
                };
                #endregion

                #region visibility

                sExperienceCertificate2.IsVisible = false;
                sExperienceCertificate3.IsVisible = false;
                sExperienceCertificate4.IsVisible = false;

                sEducationalQualification2.IsVisible = false;
                sEducationalQualification3.IsVisible = false;
                sEducationalQualification4.IsVisible = false;

                sMarksCard2.IsVisible = false;
                sMarksCard3.IsVisible = false;
                sMarksCard4.IsVisible = false;
                #endregion

                #region stack layouts, contents
                StackLayout sUploadDocuments = new StackLayout
                {
                    Children = { slblUploadDocInfo, sExperienceCertificate, sExperienceCertificate2, sExperienceCertificate3, sExperienceCertificate4, sSeparator1,
                    sEducationalQualification, sEducationalQualification2, sEducationalQualification3, sEducationalQualification4, sSeparator2,
                    sMarksCard, sMarksCard2,sMarksCard3,sMarksCard4, sSeparator3, sPanCard, sSeparator4, sAadharCard, sSeparator5, sPassport, sSeparator6, sDrivingLicense },
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    Padding = new Thickness(20, 10, 20, 0),
                    BackgroundColor = Color.White
                };
                ScrollView svUploadDocument = new ScrollView { Content = sUploadDocuments };

                Content = svUploadDocument;
                #endregion

                #region upload

                #region btnExperienceCertificateUpload
                btnExperienceCertificateUpload.Clicked += async (object sender, EventArgs e) =>
                {
                    var action = await DisplayActionSheet("Choose any one?", "Cancel", null, "Camera", "Gallery");
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        try
                        {
                            if (action == "Camera")
                            {
                                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                                {
                                    await DisplayAlert("No Camera", ":( No camera available.", "OK");
                                    return;
                                }
                                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                                {
                                    Directory = "Sample",
                                //Name = user.objectId + ".jpg"// "test.jpg"
                                Name = "test.jpg"// "test.jpg"
                            });

                                if (file == null)
                                    return;

                                await ImageSave(file.GetStream(), Constant.UserId.ToString(), "Exp_Certificate");//20 is user id. we will modify it later
                            await DisplayAlert("Upload Message", "Data is uploaded", "Ok");
                            }
                            else if (action == "Gallery")
                            {
                                if (!CrossMedia.Current.IsPickPhotoSupported)
                                {
                                    await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                                    return;
                                }
                                var file = await CrossMedia.Current.PickPhotoAsync();

                                if (file == null)
                                    return;
                                await ImageSave(file.GetStream(), Constant.UserId.ToString(), "Exp_Certificate");//20 is user id. we will modify it later
                            await DisplayAlert("Upload Message", "Data is uploaded", "Ok");

                            }

                        }
                        catch (Exception ex)
                        {
                            await DisplayAlert("Upload Message", "There was some problem while uploading data. Please try again later", "Ok", "Cancel");
                        }
                    });
                };
                #endregion

                #region btnExperienceCertificateUpload2
                btnExperienceCertificateUpload2.Clicked += async (object sender, EventArgs e) =>
                {
                    var action = await DisplayActionSheet("Choose any one?", "Cancel", null, "Camera", "Gallery");
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        try
                        {
                            if (action == "Camera")
                            {
                                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                                {
                                    await DisplayAlert("No Camera", ":( No camera available.", "OK");
                                    return;
                                }
                                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                                {
                                    Directory = "Sample",
                                Name = "test.jpg"
                            });

                                if (file == null)
                                    return;

                                await ImageSave(file.GetStream(), Constant.UserId.ToString(), "Exp_Certificate_2");
                            await DisplayAlert("Upload Message", "Data is uploaded", "Ok");
                            }
                            else if (action == "Gallery")
                            {
                                if (!CrossMedia.Current.IsPickPhotoSupported)
                                {
                                    await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                                    return;
                                }
                                var file = await CrossMedia.Current.PickPhotoAsync();

                                if (file == null)
                                    return;
                                await ImageSave(file.GetStream(), Constant.UserId.ToString(), "Exp_Certificate_2");
                                await DisplayAlert("Upload Message", "Data is uploaded", "Ok");
                            }

                        }
                        catch (Exception ex)
                        {
                            await DisplayAlert("Upload Message", "There was some problem while uploading data. Please try again later", "Ok", "Cancel");
                        }
                    });
                };
                #endregion

                #region btnExperienceCertificateUpload3
                btnExperienceCertificateUpload3.Clicked += async (object sender, EventArgs e) =>
                {
                    var action = await DisplayActionSheet("Choose any one?", "Cancel", null, "Camera", "Gallery");
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        try
                        {
                            if (action == "Camera")
                            {
                                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                                {
                                    await DisplayAlert("No Camera", ":( No camera available.", "OK");
                                    return;
                                }
                                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                                {
                                    Directory = "Sample",
                                //Name = user.objectId + ".jpg"// "test.jpg"
                                Name = "test.jpg"// "test.jpg"
                            });

                                if (file == null)
                                    return;

                                await ImageSave(file.GetStream(), Constant.UserId.ToString(), "Exp_Certificate_3");
                            await DisplayAlert("Upload Message", "Data is uploaded", "Ok");
                            }
                            else if (action == "Gallery")
                            {
                                if (!CrossMedia.Current.IsPickPhotoSupported)
                                {
                                    await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                                    return;
                                }
                                var file = await CrossMedia.Current.PickPhotoAsync();

                                if (file == null)
                                    return;
                                await ImageSave(file.GetStream(), Constant.UserId.ToString(), "Exp_Certificate_3");
                                await DisplayAlert("Upload Message", "Data is uploaded", "Ok");
                            }

                        }
                        catch (Exception ex)
                        {
                            await DisplayAlert("Upload Message", "There was some problem while uploading data. Please try again later", "Ok", "Cancel");
                        }
                    });
                };
                #endregion

                #region btnExperienceCertificateUpload4
                btnExperienceCertificateUpload4.Clicked += async (object sender, EventArgs e) =>
                {
                    var action = await DisplayActionSheet("Choose any one?", "Cancel", null, "Camera", "Gallery");
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        try
                        {
                            if (action == "Camera")
                            {
                                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                                {
                                    await DisplayAlert("No Camera", ":( No camera available.", "OK");
                                    return;
                                }
                                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                                {
                                    Directory = "Sample",
                                //Name = user.objectId + ".jpg"// "test.jpg"
                                Name = "test.jpg"// "test.jpg"
                            });

                                if (file == null)
                                    return;

                                await ImageSave(file.GetStream(), Constant.UserId.ToString(), "Exp_Certificate_4");
                            await DisplayAlert("Upload Message", "Data is uploaded", "Ok");
                            }
                            else if (action == "Gallery")
                            {
                                if (!CrossMedia.Current.IsPickPhotoSupported)
                                {
                                    await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                                    return;
                                }
                                var file = await CrossMedia.Current.PickPhotoAsync();

                                if (file == null)
                                    return;
                                await ImageSave(file.GetStream(), Constant.UserId.ToString(), "Exp_Certificate_4");
                                await DisplayAlert("Upload Message", "Data is uploaded", "Ok");
                            }

                        }
                        catch (Exception ex)
                        {
                            await DisplayAlert("Upload Message", "There was some problem while uploading data. Please try again later", "Ok", "Cancel");
                        }
                    });
                };
                #endregion

                #region btnEducationalQualificationUpload
                btnEducationalQualificationUpload.Clicked += async (object sender, EventArgs e) =>
                {
                    var action = await DisplayActionSheet("Choose any one?", "Cancel", null, "Camera", "Gallery");
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        try
                        {
                            if (action == "Camera")
                            {
                                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                                {
                                    await DisplayAlert("No Camera", ":( No camera available.", "OK");
                                    return;
                                }
                                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                                {
                                    Directory = "Sample",
                                //Name = user.objectId + ".jpg"// "test.jpg"
                                Name = "test.jpg"// "test.jpg"
                            });

                                if (file == null)
                                    return;

                                await ImageSave(file.GetStream(), Constant.UserId.ToString(), "Edu_Qualification");//20 is user id. we will modify it later
                            await DisplayAlert("Upload Message", "Data is uploaded", "Ok");
                            }
                            else if (action == "Gallery")
                            {
                                if (!CrossMedia.Current.IsPickPhotoSupported)
                                {
                                    await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                                    return;
                                }
                                var file = await CrossMedia.Current.PickPhotoAsync();

                                if (file == null)
                                    return;
                                await ImageSave(file.GetStream(), Constant.UserId.ToString(), "Edu_Qualification");
                                await DisplayAlert("Upload Message", "Data is uploaded", "Ok");
                            }

                        }
                        catch (Exception ex)
                        {
                            await DisplayAlert("Upload Message", "There was some problem while uploading data. Please try again later", "Ok", "Cancel");
                        }
                    });
                };
                #endregion

                #region btnEducationalQualificationUpload2
                btnEducationalQualificationUpload2.Clicked += async (object sender, EventArgs e) =>
                {
                    var action = await DisplayActionSheet("Choose any one?", "Cancel", null, "Camera", "Gallery");
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        try
                        {
                            if (action == "Camera")
                            {
                                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                                {
                                    await DisplayAlert("No Camera", ":( No camera available.", "OK");
                                    return;
                                }
                                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                                {
                                    Directory = "Sample",
                                //Name = user.objectId + ".jpg"// "test.jpg"
                                Name = "test.jpg"// "test.jpg"
                            });

                                if (file == null)
                                    return;

                                await ImageSave(file.GetStream(), Constant.UserId.ToString(), "Edu_Qualification_2");
                            await DisplayAlert("Upload Message", "Data is uploaded", "Ok");
                            }
                            else if (action == "Gallery")
                            {
                                if (!CrossMedia.Current.IsPickPhotoSupported)
                                {
                                    await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                                    return;
                                }
                                var file = await CrossMedia.Current.PickPhotoAsync();

                                if (file == null)
                                    return;
                                await ImageSave(file.GetStream(), Constant.UserId.ToString(), "Edu_Qualification_2");
                                await DisplayAlert("Upload Message", "Data is uploaded", "Ok");
                            }

                        }
                        catch (Exception ex)
                        {
                            await DisplayAlert("Upload Message", "There was some problem while uploading data. Please try again later", "Ok", "Cancel");
                        }
                    });
                };
                #endregion

                #region btnEducationalQualificationUpload3
                btnEducationalQualificationUpload3.Clicked += async (object sender, EventArgs e) =>
                {
                    var action = await DisplayActionSheet("Choose any one?", "Cancel", null, "Camera", "Gallery");
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        try
                        {
                            if (action == "Camera")
                            {
                                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                                {
                                    await DisplayAlert("No Camera", ":( No camera available.", "OK");
                                    return;
                                }
                                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                                {
                                    Directory = "Sample",
                                //Name = user.objectId + ".jpg"// "test.jpg"
                                Name = "test.jpg"// "test.jpg"
                            });

                                if (file == null)
                                    return;

                                await ImageSave(file.GetStream(), Constant.UserId.ToString(), "Edu_Qualification_3");
                            await DisplayAlert("Upload Message", "Data is uploaded", "Ok");
                            }
                            else if (action == "Gallery")
                            {
                                if (!CrossMedia.Current.IsPickPhotoSupported)
                                {
                                    await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                                    return;
                                }
                                var file = await CrossMedia.Current.PickPhotoAsync();

                                if (file == null)
                                    return;
                                await ImageSave(file.GetStream(), Constant.UserId.ToString(), "Edu_Qualification_3");
                                await DisplayAlert("Upload Message", "Data is uploaded", "Ok");
                            }

                        }
                        catch (Exception ex)
                        {
                            await DisplayAlert("Upload Message", "There was some problem while uploading data. Please try again later", "Ok", "Cancel");
                        }
                    });
                };
                #endregion

                #region btnEducationalQualificationUpload4
                btnEducationalQualificationUpload4.Clicked += async (object sender, EventArgs e) =>
                {
                    var action = await DisplayActionSheet("Choose any one?", "Cancel", null, "Camera", "Gallery");
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        try
                        {
                            if (action == "Camera")
                            {
                                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                                {
                                    await DisplayAlert("No Camera", ":( No camera available.", "OK");
                                    return;
                                }
                                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                                {
                                    Directory = "Sample",
                                //Name = user.objectId + ".jpg"// "test.jpg"
                                Name = "test.jpg"// "test.jpg"
                            });

                                if (file == null)
                                    return;

                                await ImageSave(file.GetStream(), Constant.UserId.ToString(), "Edu_Qualification_4");
                            await DisplayAlert("Upload Message", "Data is uploaded", "Ok");
                            }
                            else if (action == "Gallery")
                            {
                                if (!CrossMedia.Current.IsPickPhotoSupported)
                                {
                                    await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                                    return;
                                }
                                var file = await CrossMedia.Current.PickPhotoAsync();

                                if (file == null)
                                    return;
                                await ImageSave(file.GetStream(), Constant.UserId.ToString(), "Edu_Qualification_4");
                                await DisplayAlert("Upload Message", "Data is uploaded", "Ok");
                            }

                        }
                        catch (Exception ex)
                        {
                            await DisplayAlert("Upload Message", "There was some problem while uploading data. Please try again later", "Ok", "Cancel");
                        }
                    });
                };
                #endregion

                #region btnMarksCardUpload
                btnMarksCardUpload.Clicked += async (object sender, EventArgs e) =>
                {
                    var action = await DisplayActionSheet("Choose any one?", "Cancel", null, "Camera", "Gallery");
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        try
                        {
                            if (action == "Camera")
                            {
                                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                                {
                                    await DisplayAlert("No Camera", ":( No camera available.", "OK");
                                    return;
                                }
                                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                                {
                                    Directory = "Sample",
                                //Name = user.objectId + ".jpg"// "test.jpg"
                                Name = "test.jpg"// "test.jpg"
                            });

                                if (file == null)
                                    return;

                                await ImageSave(file.GetStream(), Constant.UserId.ToString(), "Marks_Card");
                            await DisplayAlert("Upload Message", "Data is uploaded", "Ok");
                            }
                            else if (action == "Gallery")
                            {
                                if (!CrossMedia.Current.IsPickPhotoSupported)
                                {
                                    await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                                    return;
                                }
                                var file = await CrossMedia.Current.PickPhotoAsync();

                                if (file == null)
                                    return;
                                await ImageSave(file.GetStream(), Constant.UserId.ToString(), "Marks_Card");
                                await DisplayAlert("Upload Message", "Data is uploaded", "Ok");
                            }

                        }
                        catch (Exception ex)
                        {
                            await DisplayAlert("Upload Message", "There was some problem while uploading data. Please try again later", "Ok", "Cancel");
                        }
                    });
                };
                #endregion

                #region btnMarksCardUpload2
                btnMarksCardUpload2.Clicked += async (object sender, EventArgs e) =>
                {
                    var action = await DisplayActionSheet("Choose any one?", "Cancel", null, "Camera", "Gallery");
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        try
                        {
                            if (action == "Camera")
                            {
                                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                                {
                                    await DisplayAlert("No Camera", ":( No camera available.", "OK");
                                    return;
                                }
                                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                                {
                                    Directory = "Sample",
                                //Name = user.objectId + ".jpg"// "test.jpg"
                                Name = "test.jpg"// "test.jpg"
                            });

                                if (file == null)
                                    return;

                                await ImageSave(file.GetStream(), Constant.UserId.ToString(), "Marks_Card_2");
                            await DisplayAlert("Upload Message", "Data is uploaded", "Ok");
                            }
                            else if (action == "Gallery")
                            {
                                if (!CrossMedia.Current.IsPickPhotoSupported)
                                {
                                    await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                                    return;
                                }
                                var file = await CrossMedia.Current.PickPhotoAsync();

                                if (file == null)
                                    return;
                                await ImageSave(file.GetStream(), Constant.UserId.ToString(), "Marks_Card_2");
                                await DisplayAlert("Upload Message", "Data is uploaded", "Ok");
                            }

                        }
                        catch (Exception ex)
                        {
                            await DisplayAlert("Upload Message", "There was some problem while uploading data. Please try again later", "Ok", "Cancel");
                        }
                    });
                };
                #endregion

                #region btnMarksCardUpload3
                btnMarksCardUpload3.Clicked += async (object sender, EventArgs e) =>
                {
                    var action = await DisplayActionSheet("Choose any one?", "Cancel", null, "Camera", "Gallery");
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        try
                        {
                            if (action == "Camera")
                            {
                                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                                {
                                    await DisplayAlert("No Camera", ":( No camera available.", "OK");
                                    return;
                                }
                                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                                {
                                    Directory = "Sample",
                                //Name = user.objectId + ".jpg"// "test.jpg"
                                Name = "test.jpg"// "test.jpg"
                            });

                                if (file == null)
                                    return;

                                await ImageSave(file.GetStream(), Constant.UserId.ToString(), "Marks_Card_3");
                            await DisplayAlert("Upload Message", "Data is uploaded", "Ok");
                            }
                            else if (action == "Gallery")
                            {
                                if (!CrossMedia.Current.IsPickPhotoSupported)
                                {
                                    await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                                    return;
                                }
                                var file = await CrossMedia.Current.PickPhotoAsync();

                                if (file == null)
                                    return;
                                await ImageSave(file.GetStream(), Constant.UserId.ToString(), "Marks_Card_3");
                                await DisplayAlert("Upload Message", "Data is uploaded", "Ok");
                            }

                        }
                        catch (Exception ex)
                        {
                            await DisplayAlert("Upload Message", "There was some problem while uploading data. Please try again later", "Ok", "Cancel");
                        }
                    });
                };
                #endregion

                #region btnMarksCardUpload4
                btnMarksCardUpload4.Clicked += async (object sender, EventArgs e) =>
                {
                    var action = await DisplayActionSheet("Choose any one?", "Cancel", null, "Camera", "Gallery");
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        try
                        {
                            if (action == "Camera")
                            {
                                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                                {
                                    await DisplayAlert("No Camera", ":( No camera available.", "OK");
                                    return;
                                }
                                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                                {
                                    Directory = "Sample",
                                //Name = user.objectId + ".jpg"// "test.jpg"
                                Name = "test.jpg"// "test.jpg"
                            });

                                if (file == null)
                                    return;

                                await ImageSave(file.GetStream(), Constant.UserId.ToString(), "Marks_Card_4");
                            await DisplayAlert("Upload Message", "Data is uploaded", "Ok");
                            }
                            else if (action == "Gallery")
                            {
                                if (!CrossMedia.Current.IsPickPhotoSupported)
                                {
                                    await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                                    return;
                                }
                                var file = await CrossMedia.Current.PickPhotoAsync();

                                if (file == null)
                                    return;
                                await ImageSave(file.GetStream(), Constant.UserId.ToString(), "Marks_Card_4");
                                await DisplayAlert("Upload Message", "Data is uploaded", "Ok");
                            }

                        }
                        catch (Exception ex)
                        {
                            await DisplayAlert("Upload Message", "There was some problem while uploading data. Please try again later", "Ok", "Cancel");
                        }
                    });
                };
                #endregion

                #region btnPanCardUpload
                btnPanCardUpload.Clicked += async (object sender, EventArgs e) =>
                {
                    var action = await DisplayActionSheet("Choose any one?", "Cancel", null, "Camera", "Gallery");
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        try
                        {
                            if (action == "Camera")
                            {
                                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                                {
                                    await DisplayAlert("No Camera", ":( No camera available.", "OK");
                                    return;
                                }
                                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                                {
                                    Directory = "Sample",
                                //Name = user.objectId + ".jpg"// "test.jpg"
                                Name = "test.jpg"// "test.jpg"
                            });

                                if (file == null)
                                    return;

                                await ImageSave(file.GetStream(), Constant.UserId.ToString(), "Pan_Card");
                            await DisplayAlert("Upload Message", "Data is uploaded", "Ok");
                            }
                            else if (action == "Gallery")
                            {
                                if (!CrossMedia.Current.IsPickPhotoSupported)
                                {
                                    await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                                    return;
                                }
                                var file = await CrossMedia.Current.PickPhotoAsync();

                                if (file == null)
                                    return;
                                await ImageSave(file.GetStream(), Constant.UserId.ToString(), "Pan_Card");
                                await DisplayAlert("Upload Message", "Data is uploaded", "Ok");
                            }

                        }
                        catch (Exception ex)
                        {
                            await DisplayAlert("Upload Message", "There was some problem while uploading data. Please try again later", "Ok", "Cancel");
                        }
                    });
                };
                #endregion

                #region btnAadharCardUpload
                btnAadharCardUpload.Clicked += async (object sender, EventArgs e) =>
                {
                    var action = await DisplayActionSheet("Choose any one?", "Cancel", null, "Camera", "Gallery");
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        try
                        {
                            if (action == "Camera")
                            {
                                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                                {
                                    await DisplayAlert("No Camera", ":( No camera available.", "OK");
                                    return;
                                }
                                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                                {
                                    Directory = "Sample",
                                //Name = user.objectId + ".jpg"// "test.jpg"
                                Name = "test.jpg"// "test.jpg"
                            });

                                if (file == null)
                                    return;

                                await ImageSave(file.GetStream(), Constant.UserId.ToString(), "Aadhar_Card");
                            await DisplayAlert("Upload Message", "Data is uploaded", "Ok");
                            }
                            else if (action == "Gallery")
                            {
                                if (!CrossMedia.Current.IsPickPhotoSupported)
                                {
                                    await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                                    return;
                                }
                                var file = await CrossMedia.Current.PickPhotoAsync();

                                if (file == null)
                                    return;
                                await ImageSave(file.GetStream(), Constant.UserId.ToString(), "Aadhar_Card");
                                await DisplayAlert("Upload Message", "Data is uploaded", "Ok");
                            }

                        }
                        catch (Exception ex)
                        {
                            await DisplayAlert("Upload Message", "There was some problem while uploading data. Please try again later", "Ok", "Cancel");
                        }
                    });
                };
                #endregion

                #region btnPassportUpload
                btnPassportUpload.Clicked += async (object sender, EventArgs e) =>
                {
                    var action = await DisplayActionSheet("Choose any one?", "Cancel", null, "Camera", "Gallery");
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        try
                        {
                            if (action == "Camera")
                            {
                                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                                {
                                    await DisplayAlert("No Camera", ":( No camera available.", "OK");
                                    return;
                                }
                                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                                {
                                    Directory = "Sample",
                                //Name = user.objectId + ".jpg"// "test.jpg"
                                Name = "test.jpg"// "test.jpg"
                            });

                                if (file == null)
                                    return;

                                await ImageSave(file.GetStream(), Constant.UserId.ToString(), "Passport");
                            await DisplayAlert("Upload Message", "Data is uploaded", "Ok");
                            }
                            else if (action == "Gallery")
                            {
                                if (!CrossMedia.Current.IsPickPhotoSupported)
                                {
                                    await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                                    return;
                                }
                                var file = await CrossMedia.Current.PickPhotoAsync();

                                if (file == null)
                                    return;
                                await ImageSave(file.GetStream(), Constant.UserId.ToString(), "Passport");
                                await DisplayAlert("Upload Message", "Data is uploaded", "Ok");
                            }

                        }
                        catch (Exception ex)
                        {
                            await DisplayAlert("Upload Message", "There was some problem while uploading data. Please try again later", "Ok", "Cancel");
                        }
                    });
                };
                #endregion

                #region btnDrivingLicenseUpload
                btnDrivingLicenseUpload.Clicked += async (object sender, EventArgs e) =>
                {
                    var action = await DisplayActionSheet("Choose any one?", "Cancel", null, "Camera", "Gallery");
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        try
                        {
                            if (action == "Camera")
                            {
                                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                                {
                                    await DisplayAlert("No Camera", ":( No camera available.", "OK");
                                    return;
                                }
                                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                                {
                                    Directory = "Sample",
                                    Name = "test.jpg"
                            });

                                if (file == null)
                                    return;

                                await ImageSave(file.GetStream(), Constant.UserId.ToString(), "Driving_License");
                            await DisplayAlert("Upload Message", "Data is uploaded", "Ok");
                            }
                            else if (action == "Gallery")
                            {
                                if (!CrossMedia.Current.IsPickPhotoSupported)
                                {
                                    await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                                    return;
                                }
                                var file = await CrossMedia.Current.PickPhotoAsync();

                                if (file == null)
                                    return;

                                await ImageSave(file.GetStream(), Constant.UserId.ToString(), "Driving_License");
                                await DisplayAlert("Upload Message", "Data is uploaded", "Ok");
                            }

                        }
                        catch (Exception ex)
                        {
                            await DisplayAlert("Upload Message", "There was some problem while uploading data. Please try again later", "Ok", "Cancel");
                        }
                    });
                };
                #endregion

                #endregion

                #region download
                #region btnExperienceCertificateDownload         
                btnExperienceCertificateDownload.Clicked += (object sender, EventArgs e) =>
               {
                   Device.BeginInvokeOnMainThread(async () =>
                   {
                       try
                       {
                           System.IO.Stream responsestream = await Download(Constant.UserId + "_Exp_Certificate.jpg");
                           byte[] byteImage = ReadFully(responsestream);
                           string file = Convert.ToBase64String(byteImage);
                           DependencyService.Get<IPicture>().SavePictureToDisk("ChartImage", byteImage, "Exp_Certificate");

                           await DisplayAlert("Download Message", "Data is downloaded", "Ok");

                       }
                       catch (Exception ex)
                       {
                           await DisplayAlert("Download Message", "Error while downloading", "Ok");
                       }
                   });
               };
                #endregion

                #region btnExperienceCertificateDownload2         
                btnExperienceCertificateDownload2.Clicked += (object sender, EventArgs e) =>
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        try
                        {

                            System.IO.Stream responsestream = await Download(Constant.UserId + "_Exp_Certificate_2.jpg");
                            byte[] byteImage = ReadFully(responsestream);
                            string file = Convert.ToBase64String(byteImage);
                            DependencyService.Get<IPicture>().SavePictureToDisk("ChartImage", byteImage, "Exp_Certificate_2");

                            await DisplayAlert("Download Message", "Data is downloaded", "Ok");

                        }
                        catch (Exception ex)
                        {
                            await DisplayAlert("Download Message", "Error while downloading", "Ok");
                        }
                    });
                };
                #endregion

                #region btnExperienceCertificateDownload3         
                btnExperienceCertificateDownload3.Clicked += (object sender, EventArgs e) =>
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        try
                        {

                            System.IO.Stream responsestream = await Download(Constant.UserId + "_Exp_Certificate_3.jpg");
                            byte[] byteImage = ReadFully(responsestream);
                            string file = Convert.ToBase64String(byteImage);
                            DependencyService.Get<IPicture>().SavePictureToDisk("ChartImage", byteImage, "Exp_Certificate_3");

                            await DisplayAlert("Download Message", "Data is downloaded", "Ok");

                        }
                        catch (Exception ex)
                        {
                            await DisplayAlert("Download Message", "Error while downloading", "Ok");
                        }
                    });
                };
                #endregion

                #region btnExperienceCertificateDownload4         
                btnExperienceCertificateDownload4.Clicked += (object sender, EventArgs e) =>
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        try
                        { 
                            System.IO.Stream responsestream = await Download(Constant.UserId + "_Exp_Certificate_4.jpg");
                            byte[] byteImage = ReadFully(responsestream);
                            string file = Convert.ToBase64String(byteImage);
                            DependencyService.Get<IPicture>().SavePictureToDisk("ChartImage", byteImage, "Exp_Certificate_4");

                            await DisplayAlert("Download Message", "Data is downloaded", "Ok");

                        }
                        catch (Exception ex)
                        {
                            await DisplayAlert("Download Message", "Error while downloading", "Ok");
                        }
                    });
                };
                #endregion

                #region btnEducationalQualificationDownload         
                btnEducationalQualificationDownload.Clicked += (object sender, EventArgs e) =>
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        try
                        {

                            System.IO.Stream responsestream = await Download(Constant.UserId + "_Edu_Qualification.jpg");
                            byte[] byteImage = ReadFully(responsestream);
                            string file = Convert.ToBase64String(byteImage);
                            DependencyService.Get<IPicture>().SavePictureToDisk("ChartImage", byteImage, "Edu_Qualification");

                            await DisplayAlert("Download Message", "Data is downloaded", "Ok");

                        }
                        catch (Exception ex)
                        {
                            await DisplayAlert("Download Message", "Error while downloading", "Ok");
                        }
                    });
                };
                #endregion

                #region btnEducationalQualificationDownload2         
                btnEducationalQualificationDownload2.Clicked += (object sender, EventArgs e) =>
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        try
                        {
                            System.IO.Stream responsestream = await Download(Constant.UserId + "_Edu_Qualification_2.jpg");
                            byte[] byteImage = ReadFully(responsestream);
                            string file = Convert.ToBase64String(byteImage);
                            DependencyService.Get<IPicture>().SavePictureToDisk("ChartImage", byteImage, "Edu_Qualification_2");

                            await DisplayAlert("Download Message", "Data is downloaded", "Ok");

                        }
                        catch (Exception ex)
                        {
                            await DisplayAlert("Download Message", "Error while downloading", "Ok");
                        }
                    });
                };
                #endregion

                #region btnEducationalQualificationDownload3         
                btnEducationalQualificationDownload3.Clicked += (object sender, EventArgs e) =>
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        try
                        {
                            System.IO.Stream responsestream = await Download(Constant.UserId + "_Edu_Qualification_3.jpg");
                            byte[] byteImage = ReadFully(responsestream);
                            string file = Convert.ToBase64String(byteImage);
                            DependencyService.Get<IPicture>().SavePictureToDisk("ChartImage", byteImage, "Edu_Qualification_3");

                            await DisplayAlert("Download Message", "Data is downloaded", "Ok");

                        }
                        catch (Exception ex)
                        {
                            await DisplayAlert("Download Message", "Error while downloading", "Ok");
                        }
                    });
                };
                #endregion

                #region btnEducationalQualificationDownload4         
                btnEducationalQualificationDownload4.Clicked += (object sender, EventArgs e) =>
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        try
                        {
                            System.IO.Stream responsestream = await Download(Constant.UserId + "_Edu_Qualification_4.jpg");
                            byte[] byteImage = ReadFully(responsestream);
                            string file = Convert.ToBase64String(byteImage);
                            DependencyService.Get<IPicture>().SavePictureToDisk("ChartImage", byteImage, "Edu_Qualification_4");

                            await DisplayAlert("Download Message", "Data is downloaded", "Ok");

                        }
                        catch (Exception ex)
                        {
                            await DisplayAlert("Download Message", "Error while downloading", "Ok");
                        }
                    });
                };
                #endregion

                #region btnMarksCardDownload         
                btnMarksCardDownload.Clicked += (object sender, EventArgs e) =>
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        try
                        {
                            System.IO.Stream responsestream = await Download(Constant.UserId + "_Marks_Card.jpg");
                            byte[] byteImage = ReadFully(responsestream);
                            string file = Convert.ToBase64String(byteImage);
                            DependencyService.Get<IPicture>().SavePictureToDisk("ChartImage", byteImage, "Marks_Card");

                            await DisplayAlert("Download Message", "Data is downloaded", "Ok");

                        }
                        catch (Exception ex)
                        {
                            await DisplayAlert("Download Message", "Error while downloading", "Ok");
                        }
                    });
                };
                #endregion

                #region btnMarksCardDownload2         
                btnMarksCardDownload2.Clicked += (object sender, EventArgs e) =>
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        try
                        {
                            System.IO.Stream responsestream = await Download(Constant.UserId + "_Marks_Card_2.jpg");
                            byte[] byteImage = ReadFully(responsestream);
                            string file = Convert.ToBase64String(byteImage);
                            DependencyService.Get<IPicture>().SavePictureToDisk("ChartImage", byteImage, "Marks_Card_2");

                            await DisplayAlert("Download Message", "Data is downloaded", "Ok");

                        }
                        catch (Exception ex)
                        {
                            await DisplayAlert("Download Message", "Error while downloading", "Ok");
                        }
                    });
                };
                #endregion

                #region btnMarksCardDownload3         
                btnMarksCardDownload3.Clicked += (object sender, EventArgs e) =>
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        try
                        {
                            System.IO.Stream responsestream = await Download(Constant.UserId + "_Marks_Card_3.jpg");
                            byte[] byteImage = ReadFully(responsestream);
                            string file = Convert.ToBase64String(byteImage);
                            DependencyService.Get<IPicture>().SavePictureToDisk("ChartImage", byteImage, "Marks_Card_3");

                            await DisplayAlert("Download Message", "Data is downloaded", "Ok");

                        }
                        catch (Exception ex)
                        {
                            await DisplayAlert("Download Message", "Error while downloading", "Ok");
                        }
                    });
                };
                #endregion

                #region btnMarksCardDownload4         
                btnMarksCardDownload4.Clicked += (object sender, EventArgs e) =>
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        try
                        {
                            System.IO.Stream responsestream = await Download(Constant.UserId + "_Marks_Card_4.jpg");
                            byte[] byteImage = ReadFully(responsestream);
                            string file = Convert.ToBase64String(byteImage);
                            DependencyService.Get<IPicture>().SavePictureToDisk("ChartImage", byteImage, "Marks_Card_4");

                            await DisplayAlert("Download Message", "Data is downloaded", "Ok");

                        }
                        catch (Exception ex)
                        {
                            await DisplayAlert("Download Message", "Error while downloading", "Ok");
                        }
                    });
                };
                #endregion

                #region btnPanCardDownload         
                btnPanCardDownload.Clicked += (object sender, EventArgs e) =>
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        try
                        {
                            System.IO.Stream responsestream = await Download(Constant.UserId + "_Pan_Card.jpg");
                            byte[] byteImage = ReadFully(responsestream);
                            string file = Convert.ToBase64String(byteImage);
                            DependencyService.Get<IPicture>().SavePictureToDisk("ChartImage", byteImage, "Pan_Card");

                            await DisplayAlert("Download Message", "Data is downloaded", "Ok");

                        }
                        catch (Exception ex)
                        {
                            await DisplayAlert("Download Message", "Error while downloading", "Ok");
                        }
                    });
                };
                #endregion

                #region btnAadharCardDownload         
                btnAadharCardDownload.Clicked += (object sender, EventArgs e) =>
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        try
                        {
                            System.IO.Stream responsestream = await Download(Constant.UserId + "_Aadhar_Card.jpg");
                            byte[] byteImage = ReadFully(responsestream);
                            string file = Convert.ToBase64String(byteImage);
                            DependencyService.Get<IPicture>().SavePictureToDisk("ChartImage", byteImage, "Aadhar_Card");

                            await DisplayAlert("Download Message", "Data is downloaded", "Ok");

                        }
                        catch (Exception ex)
                        {
                            await DisplayAlert("Download Message", "Error while downloading", "Ok");
                        }
                    });
                };
                #endregion

                #region btnPassportDownload         
                btnPassportDownload.Clicked += (object sender, EventArgs e) =>
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        try
                        {
                            System.IO.Stream responsestream = await Download(Constant.UserId + "_Passport.jpg");
                            byte[] byteImage = ReadFully(responsestream);
                            string file = Convert.ToBase64String(byteImage);
                            DependencyService.Get<IPicture>().SavePictureToDisk("ChartImage", byteImage, "Passport");

                            await DisplayAlert("Download Message", "Data is downloaded", "Ok");

                        }
                        catch (Exception ex)
                        {
                            await DisplayAlert("Download Message", "Error while downloading", "Ok");
                        }
                    });
                };
                #endregion

                #region btnDrivingLicenseDownload         
                btnDrivingLicenseDownload.Clicked += (object sender, EventArgs e) =>
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        try
                        {
                            System.IO.Stream responsestream = await Download(Constant.UserId + "_Driving_License.jpg");
                            byte[] byteImage = ReadFully(responsestream);
                            string file = Convert.ToBase64String(byteImage);
                            DependencyService.Get<IPicture>().SavePictureToDisk("ChartImage", byteImage, "Driving_License");

                            await DisplayAlert("Download Message", "Data is downloaded", "Ok");

                        }
                        catch (Exception ex)
                        {
                            await DisplayAlert("Download Message", "Error while downloading", "Ok");
                        }
                    });
                };
                #endregion

                #endregion

                #region add and remove

                #region experience certificate add and remove
                int expCertificateCount = 1;
                btnExperienceCertificateAdd.Clicked += (object sender, EventArgs e) =>
                {
                    expCertificateCount++;
                    if (expCertificateCount == 2)
                    {
                        sExperienceCertificate2.IsVisible = true;
                    }
                    if (expCertificateCount == 3)
                    {
                        sExperienceCertificate3.IsVisible = true;
                    }
                    if (expCertificateCount == 4)
                    {
                        sExperienceCertificate4.IsVisible = true;
                    }
                    if (expCertificateCount == 4)
                    {
                        btnExperienceCertificateAdd.IsEnabled = false;
                    }
                };
                btnExperienceCertificateRemove2.Clicked += (object sender, EventArgs e) =>
                {
                    if (expCertificateCount == 2)
                    {
                        sExperienceCertificate2.IsVisible = false;
                        expCertificateCount--;
                        btnExperienceCertificateAdd.IsEnabled = true;
                    }

                };
                btnExperienceCertificateRemove3.Clicked += (object sender, EventArgs e) =>
                {
                    if (expCertificateCount == 3)
                    {
                        sExperienceCertificate3.IsVisible = false;
                        expCertificateCount--;
                        btnExperienceCertificateAdd.IsEnabled = true;
                    }

                };
                btnExperienceCertificateRemove4.Clicked += (object sender, EventArgs e) =>
                {
                    if (expCertificateCount == 4)
                    {
                        sExperienceCertificate4.IsVisible = false;
                        expCertificateCount--;
                        btnExperienceCertificateAdd.IsEnabled = true;
                    }
                };

                #endregion

                #region education qualification add and remove
                int educationQualificationCount = 1;
                btnEducationalQualificationAdd.Clicked += (object sender, EventArgs e) =>
                {
                    educationQualificationCount++;
                    if (educationQualificationCount == 2)
                    {
                        sEducationalQualification2.IsVisible = true;
                    }
                    if (educationQualificationCount == 3)
                    {
                        sEducationalQualification3.IsVisible = true;
                    }
                    if (educationQualificationCount == 4)
                    {
                        sEducationalQualification4.IsVisible = true;
                    }
                    if (educationQualificationCount == 4)
                    {
                        btnEducationalQualificationAdd.IsEnabled = false;
                    }
                };
                btnEducationalQualificationRemove2.Clicked += (object sender, EventArgs e) =>
                {
                    if (educationQualificationCount == 2)
                    {
                        sEducationalQualification2.IsVisible = false;
                        educationQualificationCount--;
                        btnEducationalQualificationAdd.IsEnabled = true;
                    }

                };
                btnEducationalQualificationRemove3.Clicked += (object sender, EventArgs e) =>
                {
                    if (educationQualificationCount == 3)
                    {
                        sEducationalQualification3.IsVisible = false;
                        educationQualificationCount--;
                        btnEducationalQualificationAdd.IsEnabled = true;
                    }

                };
                btnEducationalQualificationRemove4.Clicked += (object sender, EventArgs e) =>
                {
                    if (educationQualificationCount == 4)
                    {
                        sEducationalQualification4.IsVisible = false;
                        educationQualificationCount--;
                        btnEducationalQualificationAdd.IsEnabled = true;
                    }

                };
                #endregion

                #region marks card add and remove
                int marksCardCount = 1;
                btnMarksCardAdd.Clicked += (object sender, EventArgs e) =>
                {
                    marksCardCount++;
                    if (marksCardCount == 2)
                    {
                        sMarksCard2.IsVisible = true;
                    }
                    if (marksCardCount == 3)
                    {
                        sMarksCard3.IsVisible = true;
                    }
                    if (marksCardCount == 4)
                    {
                        sMarksCard4.IsVisible = true;
                    }
                    if (marksCardCount == 4)
                    {
                        btnMarksCardAdd.IsEnabled = false;
                    }
                };
                btnMarksCardRemove2.Clicked += (object sender, EventArgs e) =>
                {
                    if (marksCardCount == 2)
                    {
                        sMarksCard2.IsVisible = false;
                        marksCardCount--;
                        btnMarksCardAdd.IsEnabled = true;
                    }

                };
                btnMarksCardRemove3.Clicked += (object sender, EventArgs e) =>
                {
                    if (marksCardCount == 3)
                    {
                        sMarksCard3.IsVisible = false;
                        marksCardCount--;
                        btnMarksCardAdd.IsEnabled = true;
                    }

                };
                btnMarksCardRemove4.Clicked += (object sender, EventArgs e) =>
                {
                    if (marksCardCount == 4)
                    {
                        sMarksCard4.IsVisible = false;
                        marksCardCount--;
                        btnMarksCardAdd.IsEnabled = true;
                    }

                };
                #endregion

                #endregion
            }
            else
            {
                Navigation.PushModalAsync(new Login());
            }

        }

    }
}
