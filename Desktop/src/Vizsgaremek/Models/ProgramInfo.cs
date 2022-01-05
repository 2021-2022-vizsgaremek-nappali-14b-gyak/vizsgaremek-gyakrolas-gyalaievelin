using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octokit;
using System.Reflection;
using System.Diagnostics;

namespace Vizsgaremek.Models
{
    public class ProgramInfo
    {
        private Version version;
        private string title;
        private string description;
        private string company;
        private string authors;


        public Version Version
        {
            get
            {
               

                var assembly = Assembly.GetExecutingAssembly();
                var assemblyVerzio = assembly.GetName().Version;
                return assemblyVerzio;
            }
        }

        public string Authors
        {
            get
            {
                return authors;
            }
        }

        public string Title
        {
            get
            {                
                return title;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
        }

        public string Company
        {
            get
            {
                return company;
            }
        }

        public ProgramInfo()
        {
            GetGithubCollaboratorsName();
            Assembly assembly = Assembly.GetExecutingAssembly();

            foreach (Attribute attr in Attribute.GetCustomAttributes(assembly))
            {
                if (attr.GetType() == typeof(AssemblyTitleAttribute))
                    title = ((AssemblyTitleAttribute)attr).Title;
                else if (attr.GetType() == typeof(AssemblyDescriptionAttribute))
                    description = ((AssemblyDescriptionAttribute)attr).Description;
                else if (attr.GetType() == typeof(AssemblyCompanyAttribute))
                    company = ((AssemblyCompanyAttribute)attr).Company;

            }
        }

        private async void GetGithubCollaboratorsName()
        {
            string reponame = "vizsgaremek-gyakrolas-gyalaievelin";
            int repoId = 431759060;
            var client = new GitHubClient(new ProductHeaderValue(reponame));

            // fejlesztők meghatározása
            try
            {
                var collaborators = await client.Repository.GetAllContributors(repoId);
                string collaboratorsName = string.Empty;
                foreach (var collaborator in collaborators)
                {
                    string collaboratorLoginName = collaborator.Login;
                    var user = await client.User.Get(collaboratorLoginName);
                    collaboratorsName += user.Name + " (" + user.Login + ") ";
                }
                authors = collaboratorsName;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

    }
}
