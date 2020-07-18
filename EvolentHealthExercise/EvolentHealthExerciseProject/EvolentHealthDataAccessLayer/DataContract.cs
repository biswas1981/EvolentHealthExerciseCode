using EvolentHealthDataAccessLayer.DataEntity;
using EvolentHealthDataModel;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EvolentHealthDataAccessLayer
{
    public class DataContract : BaseDataContract, IDataContract
    {
        public bool AddContact(EvolentHealthDataModel.Contact contact)
        {
            try
            {
                using (var dataContext = new EvolentHealthDBEntities())
                {
                    DataEntity.Contact contactData = new DataEntity.Contact
                    {
                        CreatedOn = DateTime.Now,
                        Email = contact.Email.Trim(),
                        FirstName = contact.FirstName.Trim(),
                        LastName = contact.LastName.Trim(),
                        PhoneNumber = contact.PhoneNumber.Trim(),
                        Status = contact.Status,
                        UpdatedOn = DateTime.Now
                    };
                    dataContext.Contacts.Add(contactData);
                    return dataContext.SaveChanges() > 0 ? true : false;
                }
            }
            catch
            {
                throw;
            }

        }
        public bool EditContact(EvolentHealthDataModel.Contact contact)
        {
            try
            {
                using (var dataContext = new EvolentHealthDBEntities())
                {
                    var result = dataContext.Contacts.Where(a => a.Id == contact.Id).FirstOrDefault();
                    if (result != null)
                    {
                        result.LastName = contact.LastName.Trim();
                        result.FirstName = contact.FirstName.Trim();
                        result.Email = contact.Email.Trim();
                        result.PhoneNumber = contact.PhoneNumber.Trim();
                        result.Status = contact.Status;
                        result.UpdatedOn = DateTime.Now;
                        return dataContext.SaveChanges() > 0 ? true : false;
                    }
                    else
                    {
                        return false;
                    }

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
                using (var dataContext = new EvolentHealthDBEntities())
                {
                    var result = dataContext.Contacts.Where(a => a.Id == id).FirstOrDefault();
                    if (result != null)
                    {
                        dataContext.Contacts.Remove(result);
                        return dataContext.SaveChanges() > 0 ? true : false;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        public EvolentHealthDataModel.Contact GetContactById(int id)
        {
            try
            {
                using (var dataContext = new EvolentHealthDBEntities())
                {
                    var result = dataContext.Contacts.Where(a => a.Id == id)
                        .Select(s => new EvolentHealthDataModel.Contact
                        {
                            Email = s.Email ?? "",
                            FirstName = s.FirstName ?? "",
                            Id = s.Id,
                            LastName = s.LastName ?? "",
                            PhoneNumber = s.PhoneNumber ?? "",
                            Status = s.Status
                        })
                        .FirstOrDefault();
                    if (result != null)
                    {
                        return result;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch
            {
                throw;
            }

        }

        public List<EvolentHealthDataModel.Contact> GetContactes(bool? status)
        {
            try
            {
                using (var dataContext = new EvolentHealthDBEntities())
                {
                    var result = dataContext.Contacts.Where(a => status == null || a.Status == status)
                        .Select(s => new EvolentHealthDataModel.Contact
                        {
                            Email = s.Email ?? "",
                            FirstName = s.FirstName ?? "",
                            Id = s.Id,
                            LastName = s.LastName ?? "",
                            PhoneNumber = s.PhoneNumber ?? "",
                            Status = s.Status
                        }).ToList();
                    if (result != null && result.Count() > 0)
                    {
                        return result;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch
            {
                throw;
            }

        }
    }
}
