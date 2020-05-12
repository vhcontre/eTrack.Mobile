namespace eTrack.Mobile.Services
{
    public class UserMessageResources
    {
        // Generales
        public static readonly string GenericUnknownError = "Ha ocurrido un error desconocido! Por favor, informe al Administrador.";

        // Login
        public static readonly string EmptyUserCredentials = "Las credenciales de usuario no pueden estar vacías [{0}]";
        public static readonly string InvalidUserCredentials = "Las credenciales suministradas son inválidas.";
        public static readonly string NotValidatedUserCredentials = "Las credenciales suministradas no pudieron ser validadas.";
        public static readonly string UserIsDisabled = "El usuario se encuentra inhabilitado.\r\nConsulte al Administrador.";

        // Permisos
        public static readonly string LoginNotAllowed = "No posee los permisos para acceder a esta terminal.\r\nConsulte al Administrador.";
        public static readonly string AccessNotAllowed = "No posee los permisos para acceder a esta función.\r\nConsulte al Administrador.";
        public static readonly string GetPermissionsFailed = "Los permisos del usuario no han podido ser recuperados.";

        // Conectividad
        public static readonly string DbConnectionError = "La conexión a la base de datos ha fallado.\r\nVerifique que tenga conexión a la red y que la configuración sea correcta.";
        public static readonly string NetworkAccessError = "Error de acceso a la red.\r\nVerifique que tenga conexión a la red y que la configuración sea correcta.";


        public static readonly string AssetAuditDeleteConfirmation = "Eliminará el ítem seleccionado {0}.\r\n\r\n¿Desea continuar?";

        // Despacho
        public static readonly string PickingCancellationIfContinueWarning = "Si continúa se cancelará el despacho en curso...\r\n\r\n¿Desea cancelarlo?";
        public static readonly string IncompletePickingFinishingWarning = "El despacho no esta completo...\r\n\r\n¿Desea finalizarlo incompleto?";
        public static readonly string PickingFinishingConfirmation = "Una vez finalizado el despacho no podrá ser modificado...\r\n\r\n¿Desea continuar?";
        public static readonly string PickingNotificationError = "La notificación del despacho ha fallado. Verifique la conexión a la red y la configuración.";
        public static readonly string PickingNotificationOk = "El despacho {0} ha sido notificado correctamente.";

        // Devolución
        public static readonly string ProductReturnCancellationIfContinueWarning = "Aún hay devoluciones que no han sido finalizadas...\r\n\r\n¿Desea cancelarlas?";
        public static readonly string ProductReturnFinishingConfirmation = "Una vez confirmadas las devoluciones en curso no podrán ser modificadas...\r\n\r\n¿Desea continuar?";
        public static readonly string PostProductReturnError = "La notificación de devoluciones no se ha completado. Verifique la conexión a la red y la configuración.";
        public static readonly string ProductReturnFinishInfoMessage = "La notificación de devoluciones ha finalizado.";
    }
}