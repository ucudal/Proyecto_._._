Sebastian Silveira: En primera parte, disfruté mucho la experiencia de trabajar en equipo, especialmente en lo que respecta a los desafíos relacionados con la organización y la comunicación interna. Tener algunos inconvenientes en estos aspectos me impulsó a buscar nuevas estrategias y a implementar herramientas que facilitaran la comunicación y la resolución de problemas de la manera más eficiente posible.

Por otro lado, el proyecto en sí tiene una propuesta muy interesante y motivadora. Me gusto mucho participar en su desarrollo y tengo muchas ganas de ver cómo será su implementación final. Al mismo tiempo, debo reconocer que el desarrollo del código y del flujo del programa fue bastante complejo. Esto no solo se debió a que las instrucciones en el repositorio a veces eran poco claras o pedían conceptos que nunca nos habían introducido, sino también porque gran parte del aprendizaje lo recibimos de forma muy sobre la marcha. 

Lo positivo de esta situación es que representó un desafío completo, ya que nos obligó a ingeniárnoslas para poder enfrentar problemas similares en el futuro. La posibilidad de ser creativos dentro de las limitaciones y desarrollar soluciones propias fue una experiencia muy valiosa. Sin embargo, debo admitir que, en algunos momentos, la ambigüedad fue bastante alta.

Para poder comprender ciertos conceptos y guiarme en el desarrollo de los flujos de programa, recurrí frecuentemente a videos en YouTube y a foros en internet.
Sin lugar a duda un proyecto muy desafiante y entretenido. Muy recomendable para seguirlo realizando en los siguientes años.


Alexis Giménez: Desde mi punto de vista, este proyecto ha sido una excelente manera de poner en práctica los conceptos que vemos en clase y realmente asimilarlos.

Lo que más me costó fue comenzar con el UML desde cero: comprender cómo debía funcionar cada componente y qué lógica aplicar en cada caso. Al inicio todo parecía muy abstracto, pero a medida que el diagrama fue tomando forma y empezamos a desarrollar el código, las ideas se fueron aclarando y el proceso se volvió más entretenido.

Disfruté mucho trabajar con mis compañeros. Fue una gran oportunidad para aprender a coordinar tareas en equipo, organizar horarios, comunicarnos de manera efectiva y enfrentar juntos los problemas que surgían.

En resumen, gracias a este proyecto estoy consolidando muchos de los conceptos que estudiamos en clase, mejorando mi forma de pensar de manera estructurada y resolviendo conflictos con mayor claridad. Además, siento que dentro del grupo logramos establecer una comunicación muy eficiente, lo que hizo que el trabajo fuera mucho más fluido y productivo.
En conclusión, gracias al proyecto estoy consolidando un montón de conceptos que damos en clase, me está enseñando a pensar de manera más estructurada para resolver conflictos y creo que logramos una comunicación súper eficiente dentro del grupo.


Thiago Soca: En mi caso, este proyecto fue bastante desafiante desde el principio. Hubo muchas cosas que no tenía del todo claras, sobre todo cuando empezamos a trabajar con varias clases distintas, la fachada, los gestores y toda la estructura del proyecto. Al principio me costó entender cómo encajaba cada parte y cómo debía funcionar el sistema completo. Me llevó tiempo ordenarme, también porque siento que al haber entrado tarde al curso se me hizo mas complicado, pero aun asi, fue justamente eso fue lo que más me ayudó a aprender.

Varias veces me pasó que sentía que la consigna pedía cosas que todavía no habíamos visto en clase, o que el código se volvía más complejo de lo que estaba acostumbrado. Eso me obligó a buscar la información yo, mirar ejemplos, probar distintas soluciones y equivocarme varias veces. Aunque fue frustrante por momentos, también era un alivio cuando algo funcionaba o cuando lograba entender una parte que antes no me cerraba.

En general, siento que aprendí muchísimo. No solo a programar mejor, sino a entender cómo se arma un proyecto más grande, cómo dividirlo en partes para ser mas organizado y cómo ir resolviendo de a poco. Fue un trabajo que me exigió bastante, pero que también me dejó la sensación de que realmente estoy progresando y entendiendo mejor lo que hacemos en la carrera.


Descripcion del Proyecto: Este proyecto se centra en la creación de un CRM (Customer Relationship Management) implementado como un chatbot conversacional. Su objetivo es ofrecer un sistema que facilite la gestión de clientes, incluyendo sus datos, interacciones (como llamadas, reuniones, mensajes y correos electrónicos), ventas, cotizaciones, etiquetas y reportes, todo a través de una interfaz de chat. El chatbot se integra con Discord, permitiendo a los usuarios realizar todas las funciones del CRM mediante comandos o mediante conversaciones naturales.
Por motivos de tiempo, no hemos podido completar la implementación del bot de manera óptima. Sin embargo, para la defensa del miércoles, estará completamente implementado y funcionando correctamente.

Patrones GRASP utilizados
Controller: La clase Fachada centraliza las operaciones del CRM y coordina las acciones entre los gestores y las entidades.
Creator: GestorUsuarios crea usuarios y Fachada crea clientes, porque ambas manejan las colecciones donde esos objetos se almacenan.
Information Expert: RegistroVenta conoce la lista de ventas y por eso implementa los métodos para agregarlas y filtrarlas; Cliente maneja sus propias interacciones.
Low Coupling / High Cohesion: Cada clase cumple una función específica (GestorUsuarios, RegistroVenta, Cliente, etc.), evitando depender innecesariamente de otras.

Principios SOLID aplicados
SRP: Clases como GestorUsuarios, RegistroVenta, Fachada y Cliente tienen responsabilidades bien definidas.
OCP: Nuevos tipos de interacción pueden crearse heredando de Interaccion sin modificar código existente.
LSP: Las subclases (Venta, Cotizacion, Llamada, etc.) pueden usarse donde se espera una Interaccion.












