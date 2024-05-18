﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.Entities
{
    public class Donation : BaseEntity
    {
        public Donation(int donorId, int quantityMl)
        {
            DonorId = donorId;
            QuantityMl = quantityMl;
            DateDonation = DateTime.Now;
        }

        public int DonorId { get; private set; }
        public DateTime DateDonation{ get; private set; }
        public int QuantityMl { get; private set; }
        public DonorPerson DonorPerson{ get; private set; }
    }
}
