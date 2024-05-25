using System;
using System.Runtime.Serialization;

namespace Solidarize.Domain.Enums
{
    /// <summary>
    /// Representa as diferentes naturezas legais de empresas.
    /// </summary>
    public enum LegalNature
    {
        /// <summary>
        /// Empresário Individual.
        /// </summary>
        [EnumMember(Value ="EI")]
        EI,

        /// <summary>
        /// Sociedade Limitada.
        /// </summary>
        [EnumMember(Value ="LTDA")]
        LTDA,

        /// <summary>
        /// Sociedade Anônima.
        /// </summary>
        [EnumMember(Value ="SA")]
        SA,

        /// <summary>
        /// Empresa Individual de Responsabilidade Limitada.
        /// </summary>
        [EnumMember(Value ="EIRELI")]
        EIRELI,

        /// <summary>
        /// Microempreendedor Individual.
        /// </summary>
        [EnumMember(Value ="MEI")]
        MEI,

        /// <summary>
        /// Cooperativa.
        /// </summary>
        [EnumMember(Value ="COOP")]
        COOP,

        /// <summary>
        /// Organização sem fins lucrativos.
        /// </summary>
        [EnumMember(Value = "ONG")]
        ONG
    }
}
