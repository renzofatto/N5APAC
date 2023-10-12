La inyección de dependencia se puede configurar utilizando 3 métodos: AddScoped, AddTransient y AddSingleton.

En este caso, elegí AddScoped, que crea una instancia única por cada solicitud HTTP. Al registrar IStudentLogic con AddScoped, cada solicitud HTTP en la aplicación obtendrá su propia instancia de StudentLogic. Esto beneficia la concurrencia y la gestión de estado entre diferentes solicitudes. Esto asegura que las instancias no compartan estado entre diferentes solicitudes y que cada solicitud tenga su propia lógica del estudiante.

En caso de utilizar AddTransient, se crearía una nueva instancia por cada solicitud, lo que podría llevar a problemas si necesitas mantener un estado en la instancia de StudentLogic entre múltiples solicitudes.

En caso de que hubieras utilizado AddSingleton, habría una única instancia de StudentLogic para toda la aplicación, lo cual podría no ser apropiado si se necesita instancias separadas por solicitud.