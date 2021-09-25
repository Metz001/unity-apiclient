# Proyecto 1 - Sistemas interactivos distribuidos
 Cliente Unity - RestApi(Auth) + WebSockets
 
#### Actividades del FrontEnd
1. Integrar las propuesta de dieseno para la escena de login y lobby
2. Cuando un cliente se conecte debe mostrar la liga de amigos y diferencias los que estan conectados
3. Realizar la logica para enviar y recibir  mensajes en el chat global
4. Realizar las funciones para enviar, recibir y aceptar o rechazar solicitudes de amistad 
5. Realizar la funcion para enviar un duelo directo a un amigo conectado
6. Definir la manera para cancelar el proceso de busqueda de partida

#### Considerar los siguientes escenarios
* Cuando se inicia la escena Home se debe verificar el token almacenado contra una ruta que requiera token 
* Cuando la conexion websocket se rechazada por token se deberia volver a la escena de login
* Si un amigo se desconecta se deberia recibir un evento para actualizar el estado del amigo como desconectado

Pueden surgir más necesidades durante el desarrollo
