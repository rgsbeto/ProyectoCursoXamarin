# ProyectoCursoXamarin
Proyecto final para el curso de Xamarin



Funcionalidad de la aplicación

La aplicación provee estadísticas sobre diferentes competiciones de futbol.

El punto de entrada son las competiciones disponibles, al elegir un torneo podrá conocer la lista de equipos participantes y la tabla de pocisiones.

Al seleccionar un equipo de la lista de equipos por competicion, observará información básica del mismo (nombre, fecha de fundación, sitio web), un listado con la plantilla vigente y un listado con todas las competiciones en las cuales perticipa.

Al seleccionar un equipo de la tabla de posiciones podrá ver en detalle todos los partidos programados para dicho equipo, para cada partido se mostrará el resultado final o parcial (según el estado del encuentro)



Detalle del API

El Api utilizada es https://api.football-data.org/v2/, se hace uso de las entidades Competitions, Teams, Matches y Standings

El acceso gratuito provee una cantidad limitada de competiciones y la información provista es estática. Además, se limita a 10 llamadas por minuto (por este motivo se ha implementado un chaché por medio de una tabla SQLite)

La ejecución del API requiere un token de autenticación.
