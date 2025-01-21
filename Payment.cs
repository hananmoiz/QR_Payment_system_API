using System;
using System.Collections.Generic;

namespace QR_Payment_System;

public partial class Payment
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public decimal PaymentAmount { get; set; }

    public string BranchInfo { get; set; } = null!;

    public DateTime? PaymentDate { get; set; }
}
