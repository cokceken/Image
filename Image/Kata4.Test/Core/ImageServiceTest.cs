using System.Collections.Generic;
using Kata4.Core.Contract.Repository;
using Kata4.Core.Model;
using Kata4.Core.Model.Exception;
using Kata4.Core.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Kata4.Test.Core
{
    [TestClass]
    public class ImageServiceTest
    {
        private ImageService _cut;
        private Mock<IImageRepository> _imageRepositoryMock;

        [TestInitialize]
        public void TestSetup()
        {
            _imageRepositoryMock = new Mock<IImageRepository>();

            _cut = new ImageService(_imageRepositoryMock.Object);
        }

        [TestMethod]
        public void GetImageWithIdWorksWhenFound()
        {
            _imageRepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(new Image());

            Assert.IsNotNull(_cut.GetImage(1));
        }

        [TestMethod]
        [ExpectedException(typeof(ImageNotFoundException))]
        public void GetImageWithIdThrowsExceptionWhenNotFound()
        {
            _cut.GetImage(1);
        }

        [TestMethod]
        public void GetImageWithNameWorksWhenFound()
        {
            _imageRepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(new Image());

            Assert.IsNotNull(_cut.GetImage("image"));
        }

        [TestMethod]
        [ExpectedException(typeof(ImageNotFoundException))]
        public void GetImageWithNameThrowsExceptionWhenNotFound()
        {
            _cut.GetImage("image");
        }

        [TestMethod]
        public void GetImagesWorksWhenFound()
        {
            _imageRepositoryMock.Setup(x => x.GetAll()).Returns(new List<Image>() {new Image()});

            Assert.IsNotNull(_cut.GetAllImages());
        }

        [TestMethod]
        [ExpectedException(typeof(ImageNotFoundException))]
        public void GetImagesThrowsExceptionWhenNotFound()
        {
            _cut.GetAllImages();
        }
    }
}