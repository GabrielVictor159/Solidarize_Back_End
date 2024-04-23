using System;

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
        EI,

        /// <summary>
        /// Sociedade Limitada.
        /// </summary>
        LTDA,

        /// <summary>
        /// Sociedade Anônima.
        /// </summary>
        SA,

        /// <summary>
        /// Empresa Individual de Responsabilidade Limitada.
        /// </summary>
        EIRELI,

        /// <summary>
        /// Microempreendedor Individual.
        /// </summary>
        MEI,

        /// <summary>
        /// Cooperativa.
        /// </summary>
        COOP
    }
}
