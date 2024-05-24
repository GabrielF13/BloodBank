using BloodBank.Core.Results.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.Entities.Errors
{
    public record DonorPersonErrors(string Code, string Message) : IError
    {
        public static readonly Error CannotBeCreated =
        new("DonorPerson.CannotBeCreated", "Something went wrong and the DonorPerson cannot be created");

        public static readonly Error CannotBeUpdated =
            new("DonorPerson.CannotBeUpdated", "Something went wrong and the DonorPerson cannot be updated");

        public static readonly Error CannotBeDeleted =
            new("DonorPerson.CannotBeDeleted", "Something went wrong and the DonorPerson cannot be deleted");

        public static readonly Error NotFound =
            new("DonorPerson.NotFound", "Not found");

        //public static readonly Error FinancialGoalNotFound =
        //    new("DonorPerson.FinancialGoalNotFound", "Financial Goal not found");

        //public static readonly Error FinancialGoalIsNotValid =
        //    new("DonorPerson.FinancialGoalIsNotValid", "Financial Goal is not in progress status");

        //public static readonly Error AmountIsNotValid =
        //    new("DonorPerson.AmountIsNotValid", "Amount must be greater than 0");

        //public static readonly Error DonorPersonDateIsNotValid =
        //    new("DonorPerson.DonorPersonDateIsNotValid", "DonorPerson Date cannot be earlier than today");
    }
}
