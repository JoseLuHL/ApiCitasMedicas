using System;
using System.Collections.Generic;

namespace ApiCitasMedicas.Models
{
    public partial class Recordatorio
    {
        public int RecordCodigo { get; set; }
        public int? RecordNumeroAtencion { get; set; }
        public int? RecordCodComida { get; set; }
        public string RecordHora { get; set; }
        public string RecordPreparacion { get; set; }
        public int? RecordCantidad { get; set; }

        public virtual Comida RecordCodComidaNavigation { get; set; }
        public virtual AtencionHistoria RecordNumeroAtencionNavigation { get; set; }
    }
}
