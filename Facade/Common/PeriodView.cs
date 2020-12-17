using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Abc.Facade.Common {

    public abstract class PeriodView {

        [DataType(DataType.Date)]
        [DisplayName("Valid From")]
        public DateTime? From { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Valid To")]
        public DateTime? To { get; set; }

        public abstract string GetId();

    }

}