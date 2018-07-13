# VuelingClasses
Para  que funcione el script para este proyecto que te permite crear la variable de entorno, si no esta creada es siguiendo los siguientes pasos:
- Ejecutar PowerShell como administrador.
- Desde powershel colocarse ir a la carpeta donde se ha guardado el archivo .ps1, y ejecutar el siguiente comando: set-executionpolicy unrestricted
*Por defecto está en RESTRICTED que permite comandos individuales, pero no se ejecutarán scripts.
- Pedirá la confirmación, presionar Y o S dependiendo del idioma de configuración de powershell.

En la capa de presentación tenemos que decirle que lo primero que haga es ejecutar el script:
- string cmdText = @"C:\Users\G1\source\repos\FileServer\ScripVariableEntorno.ps1"; //ruta del archivo .ps1
- Process.Start(@"C:\windows\system32\windowspowershell\v1.0\powershell.exe ", cmdText);		// ruta del .exe de powershell.

A partir de ahora al ejecutar la aplicación mirará siempre verificará si la variable de entorno está creada, en caso de que no la esté lanzará un cuadro de mensaje.
            
           
