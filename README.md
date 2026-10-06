# 🗂️ Mesa de Partes Digital

## 📌 Descripción

**Mesa de Partes Digital** es un prototipo de aplicación de escritorio desarrollado en **C# con Windows Forms**, cuyo propósito es digitalizar el registro y gestión básica de expedientes que anteriormente se realizaba de manera manual.

El proyecto nace a partir del desafío **"Del archivador al algoritmo, un prototipo para la mesa de partes digital"**, planteado en el curso de **Fundamentos de Programación**.

La aplicación busca facilitar el registro, consulta, búsqueda y organización de los expedientes, manteniendo la información de manera permanente mediante archivos de texto.

---

## 🎯 Objetivo general

Desarrollar un prototipo funcional de una Mesa de Partes Digital que permita gestionar expedientes de manera ordenada, aplicando los fundamentos de programación estudiados durante el curso.

---

## 🎯 Objetivos específicos

- Registrar información de los expedientes.
- Validar los datos ingresados.
- Consultar y buscar expedientes mediante un código de identificación.
- Ordenar los expedientes.
- Mantener la información almacenada de forma permanente mediante archivos.
- Aplicar estructuras de control, métodos, listas y manejo de excepciones.
- Desarrollar una interfaz gráfica utilizando Windows Forms.
- Gestionar el desarrollo del proyecto mediante Git y GitHub.

---

## 🖥️ Interfaz del sistema

La aplicación contará con una interfaz gráfica organizada en las siguientes secciones:

### 1. Datos del expediente

Permite ingresar la información correspondiente al expediente:

- Código de expediente
- DNI del solicitante
- Nombre del solicitante
- Asunto
- Descripción
- Fecha

### 2. Acciones

La interfaz contempla las siguientes operaciones:

- Registrar
- Buscar
- Editar
- Eliminar
- Limpiar campos

### 3. Lista de expedientes

Los expedientes registrados serán mostrados en una tabla mediante un `DataGridView`.

La información mostrada incluirá:

- Código
- DNI
- Nombre
- Asunto
- Descripción
- Fecha

### 4. Búsqueda

Permite realizar búsquedas utilizando el código del expediente o el DNI del solicitante.

### 5. Ordenamiento

Permite ordenar la lista de expedientes según el criterio seleccionado.

---

## 🛠️ Tecnologías utilizadas

- **Lenguaje:** C#
- **Entorno de desarrollo:** Visual Studio
- **Interfaz gráfica:** Windows Forms
- **Control de versiones:** Git
- **Repositorio:** GitHub
- **Persistencia:** Archivo de texto `.txt`

> El prototipo no utiliza una base de datos. La información será conservada mediante archivos de texto.

---

## 🧩 Estructura general de la solución

La aplicación seguirá una estructura sencilla:

```text
Windows Forms
      │
      ▼
Interfaz gráfica
      │
      ▼
Lista de expedientes
      │
      ▼
Archivo expedientes.txt
