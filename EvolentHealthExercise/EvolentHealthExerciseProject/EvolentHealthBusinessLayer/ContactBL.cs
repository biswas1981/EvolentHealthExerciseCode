using EvolentHealthDataAccessLayer;
using EvolentHealthDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolentHealthBusinessLayer
{
    public class ContactBL : IContactBL
    {
        public bool AddContact(Contact contact)
        {
            try
            {
                using (DataContract contract = new DataContract())
                {
                    return contract.AddContact(contact);
                }
            }
            catch
            {
                throw;
            }
        }
        public bool EditContact(Contact contact)
        {
            try
            {
                using (DataContract contract = new DataContract())
                {
                    return contract.EditContact(contact);
                }
            }
            catch
            {
                throw;
            }
        }
        public bool DeleteContact(int id)
        {
            try
            {
                using (DataContract contract = new DataContract())
                {
                    return contract.DeleteContact(id);
                }
            }
            catch
            {
                throw;
            }
        }
        public Contact GetContactById(int id)
        {
            try
            {
                using (DataContract contract = new DataContract())
                {
                    return contract.GetContactById(id);
                }
            }
            catch
            {
                throw;
            }
        }

        public List<Contact> GetContactes(bool? status)
        {
            try
            {
                using (DataContract contract = new DataContract())
                {
                    return contract.GetContactes(status);
                }
            }
            catch
            {
                throw;
            }

        }
    }
}
