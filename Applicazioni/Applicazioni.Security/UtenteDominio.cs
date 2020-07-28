using System;
using System.DirectoryServices.AccountManagement;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicazioni.Security
{
    public class UtenteDominio
    {
        private UserPrincipal userPrincipal;
        public bool PreventivatoreDistinteBase { get; private set; }
        public bool PreventivatoreCosti { get; private set; }
        public bool PreventivatoreAnagrafiche { get; private set; }

        public bool SpedizioniMagazzino { get; private set; }
        public bool SpedizioniSaldi { get; private set; }
        public bool SpedizioniMovimenta { get; private set; }


        public string DisplayName { get; private set; }
        public string FULLNAMEUSER { get; private set; }

        public string IDUSER { get; private set; }

        public UtenteDominio()
        {
            string username = Environment.UserName;

            PreventivatoreAnagrafiche = false;
            PreventivatoreCosti = false;
            PreventivatoreDistinteBase = false;

            SpedizioniSaldi = false;
            SpedizioniMagazzino = false;
            SpedizioniMovimenta = false;

            FULLNAMEUSER = "Sconosciuto";
            DisplayName = "Sconosciuto";
            IDUSER = string.Empty;

            //  PrincipalContext domainctx = new PrincipalContext(ContextType.Domain,"example","DC=example,DC=com");
            PrincipalContext domainctx = new PrincipalContext(ContextType.Domain);

            userPrincipal = UserPrincipal.FindByIdentity(domainctx, IdentityType.SamAccountName, username);

            if (userPrincipal != null)
            {
                PreventivatoreAnagrafiche = userPrincipal.IsMemberOf(domainctx, IdentityType.Name, GruppiDominio.PreventivatoreAnagrafiche);
                PreventivatoreCosti = userPrincipal.IsMemberOf(domainctx, IdentityType.Name, GruppiDominio.PreventivatoreCosti);
                PreventivatoreDistinteBase = userPrincipal.IsMemberOf(domainctx, IdentityType.Name, GruppiDominio.PreventivatoreDistinteBase);

                SpedizioniMagazzino = userPrincipal.IsMemberOf(domainctx, IdentityType.Name, GruppiDominio.SpedizioniMagazzino);
                SpedizioniSaldi = userPrincipal.IsMemberOf(domainctx, IdentityType.Name, GruppiDominio.SpedizioniSaldi);
                SpedizioniMovimenta = userPrincipal.IsMemberOf(domainctx, IdentityType.Name, GruppiDominio.SpedizioniMovimenta);

                FULLNAMEUSER = userPrincipal.DisplayName.Length > 50 ? userPrincipal.DisplayName.Substring(0, 50) : userPrincipal.DisplayName;
                IDUSER = userPrincipal.UserPrincipalName;
                DisplayName = userPrincipal.DisplayName;
            }
        }
    }
}
