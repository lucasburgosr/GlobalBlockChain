# GlobalLabIII
Sistema de asientos contables desarrollado en C# y utilizando Blockchain para registrar las transacciones.

Clases Actualizadas:

Cuenta:
Atributos:
IDCuenta (identificador único de la cuenta)
Nombre (nombre de la cuenta)
Otros atributos que puedan ser relevantes para una cuenta contable.
Métodos:
Métodos relacionados con la gestión de cuentas.

Transaccion:
Atributos:
IDTransaccion (identificador único de la transacción)
Cuenta (instancia de la clase Cuenta asociada a la transacción)
Monto (monto de la transacción)
TipoMovimiento (débito o crédito)
Fecha (fecha de la transacción)
Otros atributos que puedan ser relevantes para una transacción.

Asiento:
Atributos:
IDAsiento (identificador único del asiento contable)
Fecha (fecha del asiento)
Descripcion (descripción del asiento)
Transacciones (lista de transacciones asociadas al asiento).

LibroMayor:
Este podría ser más bien una clase que proporciona métodos para consultar el Libro Mayor, en lugar de representar directamente un objeto en sí mismo.
Métodos:
Métodos para consultar el Libro Mayor.

Consideraciones:

Vista de Registro de Transacción:
Al registrar una transacción desde un formulario, puedes tener un método en tu aplicación que tome la información del formulario y cree una nueva instancia de la clase Transaccion con los datos proporcionados.

Método de RegistrarTransaccion (en la clase Asiento):
Este método podría actualizarse para recibir directamente los parámetros del formulario y crear la instancia de Transaccion antes de agregarla al asiento.

Cuenta en Transaccion:
Ahora, la transacción tiene un atributo Cuenta que es una instancia de la clase Cuenta. Esto facilita la asociación directa de una transacción con una cuenta.

Validaciones:
Puedes realizar validaciones adicionales en el formulario antes de crear la transacción, por ejemplo, asegurándote de que la cuenta seleccionada exista en el plan de cuentas.
