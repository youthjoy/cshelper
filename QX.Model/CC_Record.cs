using System;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace QX.Model
{
   [Serializable]
   public partial class CC_Record
   {
      private decimal cCR_ID;
      private bool cCR_ID_IsChanged=false;
      public decimal CCR_ID
      {
         get{ return cCR_ID; }
         set{ cCR_ID = value; cCR_ID_IsChanged=true; }
      }
      public bool CCR_ID_IsChanged
      {
         get{ return cCR_ID_IsChanged; }
         set{ cCR_ID_IsChanged = value; }
      }
   }
}
