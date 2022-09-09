IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'par_petiquetas')
TRUNCATE TABLE parametros.par_petiquetas
GO
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'par_pmensajes')
TRUNCATE TABLE parametros.par_pmensajes

GO
--NavBar
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'aboutus', 'Sobre nosotros','About us', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'packages', 'Paquetes', 'Packages', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'login', 'Iniciar sesión', 'Log in', GetDate(), NULL,0,'ADMIN');

--Titulos About Us
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'title1-aboutus', 'Educación personalizada', 'Personalized education', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'title2-aboutus', 'Aprendizaje divertido', 'Fun learning', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'title3-aboutus', 'Accesible universalmente', 'Universally accessible', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'title4-aboutus', 'Sobre ITrivia', 'About ITrivia', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'title5-aboutus', '¿No es suficiente?', 'Not enough?', GetDate(), NULL,0,'ADMIN');
--Subtitulos About Us
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'subtitle1-aboutus', 'Inclusión', 'Inclusion', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'subtitle2-aboutus', 'Documentación detallada', 'Detailed documentation', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'subtitle3-aboutus', 'Métodos de enseñanza modernos', 'Modern teaching methods', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'subtitle4-aboutus', 'Vea un ejemplo de como funciona ITrivia', 'See an example of how ITrivia works', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'subtitle5-aboutus', 'Gratis para uso personal', 'Free for personal use', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'subtitle6-aboutus', '100+ Desafíos', '100+ Challenges', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'subtitle7-aboutus', 'Múltiples modalidades de juego', 'Multiple game modes', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'subtitle8-aboutus', 'Paquetes premium', 'Premium packages', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'subtitle9-aboutus', 'Material profesional', 'Professional material', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'subtitle10-aboutus', 'Fácil acceso', 'Easy access', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'subtitle11-aboutus', 'Ranking general', 'Overall ranking', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'subtitle12-aboutus', 'Gráficas de progreso semanal', 'Weekly progress graphs', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'subtitle13-aboutus', 'Comparte en redes sociales', 'Share on social networks', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'subtitle14-aboutus', 'Actualización de contenidos', 'Content update', GetDate(), NULL,0,'ADMIN');
--Textos About Us
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'text-aboutus1', 'SE MÁS EFECTIVO', 'BE MORE EFFECTIVE', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'text-aboutus2', 'Registrate y aprendé desde donde estes.', 'Register and learn from wherever you are.', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'text-aboutus3', 'Cada persona aprende de forma diferente. Para crear el sistema educacional más efectivo posible y adaptarlo a las necesidades del estudiante y o profesional.', 'Everyone learns differently. To create the most effective educational system possible and adapt it to the needs of the student and or professional.', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'text-aboutus4', 'Es difícil mantenerse motivado cuando aprendes en línea, así que hicimos Trivia divertido para que la gente prefiera aprender nuevas habilidades en lugar de jugar un juego que no aporte contenido educativo.', 'It´s hard to stay motivated when you learn online, so we made Trivia fun so people would rather learn new skills than play a game that doesn´t provide educational content.', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'text-aboutus5', 'Desafortunadamente, acceder a una educación de material tecnológico resulta ser muy costoso y para muchos, inaccesible. Creamos Trivia para que todos tuvieran igualdad de oportunidades. Aprendizaje gratuito, ya que la verdadera igualdad es cuando la mejor educación es accesible a todos, no importa cuánto dinero tengas.', 'Unfortunately, accessing an education of technological material is very expensive and for many, inaccessible. We created Trivia so that everyone would have equal opportunities. Free learning, because true equality is when the best education is accessible to everyone, no matter how much money you have.', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'text-aboutus6', 'Plataformas de formación online como Trivia, permiten que todos los estudiantes puedan preguntar sus dudas tanto a sus tutores, como en diferentes grupos de trabajo. De esta manera, se establece una forma de trabajo colaborativo entre profesores y alumnos.', 'Online training platforms such as Trivia, allow all students to ask their questions to their tutors, as well as in different work groups. In this way, a form of collaborative work between teachers and students is established.', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'text-aboutus7', 'La documentación detallada sirve como refuerzo de la enseñanza que se ofrece en el aula. De esta manera, se puede analizar lo que han aprendido los alumnos, mejorando la información y los materiales que se ofrecen.', 'Detailed documentation serves as a reinforcement of the teaching offered in the classroom. In this way, it is possible to analyze what the students have learned, improving the information and materials offered.', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'text-aboutus8', 'Anualmente los centros educativos invierten miles de dólares en material escolar ,donde gran parte de estos se pueden ahorrar , incluyendo todo su conocimiento sobre la materia en esta plataforma.', 'Every year schools invest thousands of dollars in school supplies, where a large part of these can be saved by including all their knowledge about the subject on this platform.', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'text-aboutus9', 'Disponemos de registro gratuito para personas ,con un límite de secciones que te ayudarán a aprender !', 'We have free registration for people with a limited number of sections that will help you learn !', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'text-aboutus10', 'Te encontrarás con múltiples secciones y desafíos que pondrán a prueba tu conocimiento.', 'You will find multiple sections and challenges that will test your knowledge.', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'text-aboutus11', 'Contamos con diversas modalidades de juego para no tornar el aprendizaje monótono.', 'We have several game modes so as not to make learning monotonous.', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'text-aboutus12', 'Ofrecemos paquetes premium para poder descubrir nuevos desafíos, nuevas secciones y aumentar el conocimiento al máximo!', 'We offer premium packages so you can discover new challenges, new sections and increase your knowledge to the maximum!', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'text-aboutus13', 'Redactado por nuestros profesionales.', 'Written by our professionals.', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'text-aboutus14', 'No hacen falta mas pasos, con solo tienes que registrarte y ya podes comenzar a jugar con nosotros!', 'No more steps are needed, just register and you can start playing with us!', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'text-aboutus15', 'Compite con tus amigos para ver quien es el que más sabe sobre el mundo IT.', 'Compete with your friends to see who knows the most about the IT world.', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'text-aboutus16', 'Observa tu avance con nuestros gráficos de progreso semanal ,para tomar nota de tu rendimiento.', 'Watch your progress with our weekly progress graphs to keep track of your performance.', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'text-aboutus17', 'Comparte tus resultados en las redes sociales para que todos tus contactos lo vean!', 'Share your results on social networks for all your contacts to see!', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'text-aboutus18', 'Actualizaremos el contenido para que no quede atrasado en comparación a las nuevas tendencias.', 'We will update the content so that it does not lag behind new trends.', GetDate(), NULL,0,'ADMIN');

--Footer
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'footer', 'Todos los derechos de ITrivia reservados', 'Copyright © ITrivia. All rights reserved.', GetDate(), NULL,0,'ADMIN');	

--Títulos Packages
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'title-package1', 'Individual', 'Individual', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'title-package2', 'Educativo', 'Educational', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'title-package3', 'Empresarial', 'Business', GetDate(), NULL,0,'ADMIN');
--Textos Package
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'text-package1', 'Sección/es', 'Section/s', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'text-package2', 'Desafío/s', 'Challenge/s', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'text-package3', 'Comprar', 'Buy', GetDate(), NULL,0,'ADMIN');

--Login 
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'signup', 'Registrarte', 'Sign Up', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'email', 'Correo electrónico', 'E-mail', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'password', 'Contraseña', 'Password', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'confirm-password', 'Confirmar Contraseña', 'Confirm Password', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'recovery-password', 'Recuperar contraseña', 'Recovery password', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'send', 'Enviar', 'Send', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'login-name', 'Nombre', 'Name', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'login-lastname', 'Apellido', 'Surname', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'check-business', 'Soy una Empresa', 'I am a Company', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'company-name', 'Nombre de la Empresa', 'Company Name', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'phone', 'Número de teléfono', 'Phone number', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'forgot-password', '¿Olvidaste tu contraseña?', 'Forgot your password?', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'back-login', 'Volver al menú de sesión', 'Back to session menu', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'back-login2', '¿Tu ya tienes una cuenta? Ingresa !', 'Already have an account? Sign in !', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'title-signup', 'Inscríbete y comienza a aprender.', 'Sign up and start learning.', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'remembersession', 'Recordar sessión', 'Remember session', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'user', 'Usuario', 'User', GetDate(), NULL,0,'ADMIN');

--Valicadiones de Login y SignUp
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'validate-password-login', 'Usuario o contraseña incorrecto.', 'Incorrect username or password.', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'validate-name-signup', 'El campo Nombre es requerido.', 'The Name field is required.', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'validate-surname-signup', 'El campo Apellido es requerido.', 'The Surname field is required.', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'validate-email-signup', 'El campo Correo electrónico es requerido.', 'The Email field is required.', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'validate-password-signup', 'El campo Contraseña es requerido.', 'The Password field is required.', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'validate-password2-signup', 'Las contraseñas no coinciden.', 'Passwords do not match.', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'validate-cuit-signup', 'El campo CUIT es requerido.', 'The CUIT field is required.', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'validate-phone-signup', 'El campo teléfono es requerido.', 'The phone field is required.', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'validate-emailformat-signup', 'Formato Inválido (por ejemplo, alguien@ejemplo.com).', 'Invalid format (for example, someone@example.com).', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'validate-passwordlenght-signup', 'La contraseña debe tener al menos 6 caracteres.', 'The password must be at least 6 characters long.', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'validate-cuitlenght-signup', 'El CUIT debe tener al menos 8 caracteres.', 'The CUIT must be at least 8 characters long.', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'validate-phonelenght-signup', 'El teléfono debe tener 10 caracteres.', 'The phone must be  10 characters long.', GetDate(), NULL,0,'ADMIN');

--Toastr
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'toast-success', '¡Registro exioso!', 'Registration successful!', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'toast-success2', 'Nuevo usuario creado.', 'New User created.', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'toast-failed', '¡Registro fallido!', 'Registration failed!', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'toast-failed2', 'Este correo ya se encuentra en uso.', 'This email is already in use.', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'toast-login-admin', 'Este empresa ya se encuentra registrada.', 'This company is already registered.', GetDate(), NULL,0,'ADMIN');


------------------------------------------------------------------------Managment------------------------------------------------------------------------
--SideBar
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'explore', 'Explorar', 'Explore', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'progress', 'Progreso', 'Progress', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'progress-1', 'Experiencia semanal', 'Weekly experience', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'progress-2', 'Ranking General', 'General Ranking', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'exp-weekly', 'Exp. Semanal', 'Weekly experience', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'exp-weekly2', 'Experiencia Semanal', 'Weekly experience', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'rank-gen', 'Ranking General', 'General ranking', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'profile', 'Perfil', 'Profile', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'logout', 'Cerrar sesión', 'Log out', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'exp', 'Experiencia', 'Experience', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'configuration', 'Configuración', 'Configuration', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'users', 'Usuarios', 'Users', GetDate(), NULL,0,'ADMIN');


--Secciones
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'sections', 'Secciones', 'Sections', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'categories', 'Categorias..', 'Categories..', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'search', 'Buscar', 'Search', GetDate(), NULL,0,'ADMIN');

--Card-sections
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'enter', 'Entrar', 'Enter', GetDate(), NULL,0,'ADMIN');

--Desafios
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'challenges', 'Desafíos', 'Challenges', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'play', 'Jugar', 'Play', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'chapter', 'Capítulo', 'Chapter', GetDate(), NULL,0,'ADMIN');

--Progreso [Ranking General]
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'fullname', 'Nombre y Apellido', 'Name and Surname', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'points', 'Puntos', 'Points', GetDate(), NULL,0,'ADMIN');


-- Imagenes
INSERT INTO parametros.par_pimagenes (alta_fecha,codigo,url_imagen,usuario) VALUES (CURRENT_TIMESTAMP,'ADMIN','http://imgfz.com/i/UaHNYkw.png','USR_ITRIVIA');
INSERT INTO parametros.par_pimagenes (alta_fecha,codigo,url_imagen,usuario) VALUES (CURRENT_TIMESTAMP,'USER','http://imgfz.com/i/Z3td27W.png','USR_ITRIVIA');
INSERT INTO parametros.par_pimagenes (alta_fecha,codigo,url_imagen,usuario) VALUES (CURRENT_TIMESTAMP,'ADMINCOMPANY','http://imgfz.com/i/xUA704y.png','USR_ITRIVIA');
INSERT INTO parametros.par_pimagenes (alta_fecha,codigo,url_imagen,usuario) VALUES (CURRENT_TIMESTAMP,'COMPANYUSER','http://imgfz.com/i/iT8CAnq.png','USR_ITRIVIA');


--Perfiles
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'explore-sections', 'Explorar secciones', 'Explore sections', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'challenges-completed', 'Desafíos completados', 'Challenges completed', GetDate(), NULL,0,'ADMIN');

--Modal.
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'edit-successful', '¡Editado con éxito!', 'Edited successfully!', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'edit-successful-s', '¡Sección editada!', 'Edited Section!', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'edit-successful-c', '¡Desafío editado!', 'Edited Challenge!', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'edit-successful-u', '¡Usuario editado!', 'Edited User!', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'edit-successful-st', '¡Etapa editada!', 'Edited Step!', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'edit-failed', 'Revise que los campos no coincidan con alguno existente.', 'Check that the fields do not match any existing ones.', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'create-successful', '¡Creado con éxito!', 'Edited successfully!', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'create-successful-s', '¡Sección creada!', 'Created Section!', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'create-successful-c', '¡Desafío creado!', 'Created Challenge!', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'create-successful-u', '¡Usuario creado!', 'Created User!', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'create-successful-st', '¡Etapa creada!', 'Created Step!', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'operation-successful', '¡Operación exitosa!', 'Successful Operation!', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'delete-section', '¡Sección eliminada!', 'Deleted Section!', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'delete-challenge', '¡Desafío eliminado!', 'Deleted Challenge!', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'delete-user', '¡Usuario eliminado!', 'Deleted User!', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'delete-step', '¡Etapa eliminado!', 'Deleted Step!', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'required-field', '¡Es un campo requerido!', 'Its a required field!', GetDate(), NULL,0,'ADMIN');

--ABM
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'abm-sections', 'ABM Secciones', 'Sections ABM', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'abm-challenges', 'ABM Desafíos', 'Challenges ABM', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'abm-users', 'ABM Usuarios', 'Users ABM', GetDate(), NULL,0,'ADMIN');


INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'new', 'Nuevo', 'New', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'name', 'Nombre', 'Name', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'category', 'Categoría', 'Category', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'step', 'Etapa', 'Step', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'steps', 'Etapas', 'Steps', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'type-game', 'Tipo de juego', 'Game Type', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'amount-challenges', 'Cantidad de Desafíos', 'Amount of Challenges', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'discharge-date', 'Fecha de Alta', 'Begin Date', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'action', 'Acción', 'Action', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'state', 'Estado', 'State', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'description', 'Descripción', 'Description', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'max-length', 'Máximo 50 caracteres', 'Maximum 50 characters', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes]([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'url-image', 'URL de Imagen', 'URL Image', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'available-users', 'Usuarios disponibles para crear :', 'Available Users to create :', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'save', 'Grabar', 'Save', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'cancel', 'Cancelar', 'Cancel', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'section', 'Sección', 'Section', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'amount-steps', 'Cantidad de Etapas', 'Amount of Steps', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'score', 'Puntaje', 'Score', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'exp-points', 'Puntos de experiencia', 'Points of experience', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'select-category', 'Seleccione una Categoría', 'Select a category', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'select-section', 'Seleccione una Sección', 'Select a section', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'select-game', 'Seleccione un tipo de juego', 'Select a game type', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'option', 'Opción', 'Option', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'answer', 'Respuesta', 'Answer', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'answer-correct', 'Respuesta correcta', 'Correct answer', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'answer-incorrect', 'Respuesta incorrecta', 'Incorrect answer', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'enunciate', 'Enunciado', 'Enunciate', GetDate(), NULL,0,'ADMIN');


INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'edit-s', 'Editar Sección', 'Edit Section', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'edit-c', 'Editar Desafío', 'Edit Challenge', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'edit-u', 'Editar Usuario', 'Edit User', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'edit-uc', 'Editar Contraseña', 'Edit Password', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'edit-st', 'Editar Etapa', 'Edit Step', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'del-s', 'Eliminar Sección', 'Delete Section', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'del-c', 'Eliminar Desafío', 'Delete Challenge', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'del-u', 'Eliminar Usuario', 'Delete User', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'del-st', 'Eliminar Etapa', 'Delete Step', GetDate(), NULL,0,'ADMIN');

INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'useradmincount-failed', 'Su empresa ya alcanzo el limite de usuarios a crear', 'Your company has already reached the limit of users to create', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'min', 'Mínimo ', 'Minimum', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'max', 'Máximo ', 'Maximum', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_petiquetas] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'char', 'caracteres ', 'characters', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'errormark', 'Se debe ingregar solo una vez la marca <#aut> para indicar la respuesta', 'The <#aut> mark must be entered only once to indicate the answer', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'err-delete-section', 'No se puede eliminar sección, posee desafio asociado', 'Cannot delete section, it has an associated challenge', GetDate(), NULL,0,'ADMIN');

--Validaciones de cantidad ABM
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'users-quantity', 'Usuarios creados ', 'Users created ', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'steps-quantity', 'Etapas creadas', 'Steps created ', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'challenges-quantity', 'Desafíos creadas', 'Challenges created ', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'steps-empty', 'No hay etapas', 'No steps ', GetDate(), NULL,0,'ADMIN');
INSERT INTO [parametros].[par_pmensajes] ([nombre], [codigo], [espanol], [ingles], [alta_fecha], [modi_fecha], [baja], [usuario]) VALUES ('', 'challenges-empty', 'No hay desafíos', 'No challenges ', GetDate(), NULL,0,'ADMIN');
