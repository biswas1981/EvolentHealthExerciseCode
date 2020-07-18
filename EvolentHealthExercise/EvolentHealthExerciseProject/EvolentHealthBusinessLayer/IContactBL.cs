﻿using EvolentHealthDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolentHealthBusinessLayer
{
    public interface IContactBL
    {
        bool AddContact(Contact contact);
        bool EditContact(Contact contact);
        bool DeleteContact(int id);
        Contact GetContactById(int id);
        List<Contact> GetContactes(bool? status);
    }
}
