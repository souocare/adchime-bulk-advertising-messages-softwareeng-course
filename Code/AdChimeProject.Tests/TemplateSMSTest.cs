using AdChimeProject.Persistence.Services;
using System;
using Xunit;
using AdChimeProject.Tests.Persistence.Repositories;
using System.Collections.Generic;
using System.Linq;
using Xunit.Abstractions;

namespace AdChimeProject.Tests
{
    public class TemplateSMSTest
    {
        private readonly ITestOutputHelper _output;
        public TemplateSMSTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void GetTemplateTeste()
        {
            InMemoryTemplateSMSRepository inMemoryTemplateSMSRepository = new InMemoryTemplateSMSRepository();
            TemplateSMSService templatesmsservice = new TemplateSMSService(inMemoryTemplateSMSRepository);
            TemplateSMS templatesms_teste = new TemplateSMS
            {
                idtemplate = 1,
                Title = "Title1",
                Text = "Text1",
                isaproved = true,
                insertdate = DateTime.Now,
                updatedate = DateTime.Now,
                updatedbyuser = "teste"
            };
            inMemoryTemplateSMSRepository.Add(templatesms_teste);

            // Testing the GetContactById method
            var check_iftemplatecreated = templatesmsservice.GetTemplateById(1);
            Assert.Equal(templatesms_teste, check_iftemplatecreated);
            Assert.Equal(templatesms_teste.Title, check_iftemplatecreated.Title);
            _output.WriteLine("Finished GetContactTeste...\n\n");
        }




        [Fact]
        public void GetAllTemplatesTeste()
        {
            InMemoryTemplateSMSRepository inMemoryTemplateSMSRepository = new InMemoryTemplateSMSRepository();
            TemplateSMSService templatesmsservice = new TemplateSMSService(inMemoryTemplateSMSRepository);
            TemplateSMS templatesms_teste = new TemplateSMS
            {
                idtemplate = 1,
                Title = "Title1",
                Text = "Text1",
                isaproved = true,
                insertdate = DateTime.Now,
                updatedate = DateTime.Now,
                updatedbyuser = "teste"
            };
            inMemoryTemplateSMSRepository.Add(templatesms_teste);

            TemplateSMS templatesms_testedois = new TemplateSMS
            {
                idtemplate = 2,
                Title = "Title2",
                Text = "Text2",
                isaproved = true,
                insertdate = DateTime.Now,
                updatedate = DateTime.Now,
                updatedbyuser = "teste"
            };
            inMemoryTemplateSMSRepository.Add(templatesms_testedois);


            // Testing the RemovebyId method
            var check_allcontacts = templatesmsservice.GetAllTemplates();
            Assert.Equal(2, check_allcontacts.Count());
            _output.WriteLine("Finished GetAllTemplatesTeste...\n\n");
        }



        [Fact]
        public void AddTemplateTeste()
        {
            InMemoryTemplateSMSRepository inMemoryTemplateSMSRepository = new InMemoryTemplateSMSRepository();
            TemplateSMSService templatesmsservice = new TemplateSMSService(inMemoryTemplateSMSRepository);
            templatesmsservice.AddTemplate("Title", "Texto", true);
            var allcontacts = templatesmsservice.GetAllTemplates();
            Assert.Equal("Texto", allcontacts.ToList()[0].Text);
            _output.WriteLine("Finished AddTemplateTeste...\n\n");
        }


        [Fact]
        public void EditTemplateTeste()
        {
            InMemoryTemplateSMSRepository inMemoryTemplateSMSRepository = new InMemoryTemplateSMSRepository();
            TemplateSMSService templatesmsservice = new TemplateSMSService(inMemoryTemplateSMSRepository);
            TemplateSMS templatesms_teste = new TemplateSMS
            {
                idtemplate = 1,
                Title = "Title1",
                Text = "Text1",
                isaproved = true,
                insertdate = DateTime.Now,
                updatedate = DateTime.Now,
                updatedbyuser = "teste"
            };
            inMemoryTemplateSMSRepository.Add(templatesms_teste);

            // Testing the GetContactById method
            var check_ifuseredited = templatesmsservice.EditTemplate("Title_edited", "Text_edited", false, DateTime.Now, "goncalo.fonseca", 1);
            Assert.Equal("Text_edited", check_ifuseredited.Text);
            _output.WriteLine("Finished EditTemplateTeste...\n\n");
        }


        [Fact]
        public void GetAllApprovedTemplatesTeste()
        {
            InMemoryTemplateSMSRepository inMemoryTemplateSMSRepository = new InMemoryTemplateSMSRepository();
            TemplateSMSService templatesmsservice = new TemplateSMSService(inMemoryTemplateSMSRepository);
            TemplateSMS templatesms_teste = new TemplateSMS
            {
                idtemplate = 1,
                Title = "Title1",
                Text = "Text1",
                isaproved = true,
                insertdate = DateTime.Now,
                updatedate = DateTime.Now,
                updatedbyuser = "teste"
            };
            inMemoryTemplateSMSRepository.Add(templatesms_teste);

            TemplateSMS templatesms_testedois = new TemplateSMS
            {
                idtemplate = 2,
                Title = "Title2",
                Text = "Text2",
                isaproved = false,
                insertdate = DateTime.Now,
                updatedate = DateTime.Now,
                updatedbyuser = "teste"
            };
            inMemoryTemplateSMSRepository.Add(templatesms_testedois);

            // Testing the RemovebyId method
            var check_allcontacts = templatesmsservice.GetApprovedTemplates();
            Assert.Equal(1, check_allcontacts.Count());
            _output.WriteLine("Finished GetAllApprovedTemplatesTeste...\n\n");
        }


        [Fact]
        public void GetTemplateInfo()
        {
            InMemoryTemplateSMSRepository inMemoryTemplateSMSRepository = new InMemoryTemplateSMSRepository();
            TemplateSMSService templatesmsservice = new TemplateSMSService(inMemoryTemplateSMSRepository);
            TemplateSMS templatesms_teste = new TemplateSMS
            {
                idtemplate = 1,
                Title = "Title1",
                Text = "Text1",
                isaproved = true,
                insertdate = DateTime.Now,
                updatedate = DateTime.Now,
                updatedbyuser = "teste"
            };
            inMemoryTemplateSMSRepository.Add(templatesms_teste);

            // Testing the GetContactById method
            var check_templateinfo = templatesmsservice.GetTemplateById(1);
            Assert.Equal(templatesms_teste.Text, check_templateinfo.Text);
            _output.WriteLine("Finished GetTemplateInfo...\n\n");
        }

    }
}
