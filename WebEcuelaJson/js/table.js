const $$DomTable = function () {
  this.row = function (parent) {
    const row = $dc.createAndAppend(parent, "tr");
    return row;
  };
  this.dataCell = function (parent) {
    const dataCell = $dc.createAndAppend(parent, "td"); // Data cell
    return dataCell;
  };
  this.headerCell = function (parent) {
    const headerCell = $dc.createAndAppend(parent, "th"); // Header cell
    return headerCell;
  };

  this.createTable = function () {
    const containerMain= $d.querySelector("main")
    const containerTable=$dc.div(containerMain);
    containerTable.classList.add("container__table");
    const table = $dc.createAndAppend(containerTable, "table");
  };
  this.createThead = function () {
    const table = $d.querySelector("table");
    const tableHeader = $dc.createAndAppend(table, "thead");
    tableHeader.classList.add("tableHeader");
    return tableHeader;
  };
  this.createTbody = function () {
    const table = $d.querySelector("table");
    const tbody = $dc.createAndAppend(table, "tbody");
  };
  let isTable = function() {
    const table = $d.querySelector("table");
    return table !== null;
  };
  this.table = function (listTitles, data) {
    if (isTable()) {
      this.addTbodyItem(data);
           
    }else
    {
      this.createTable();
      this.createThead();
      this.createTbody();
      this.addTheadTitle(listTitles);
      this.addTbodyItem(data);
    }
  };

  this.addTheadTitle = function (listTitles) {
    tableHeader = $d.querySelector("thead");
    const headerRow = this.row(tableHeader);
    listTitles.forEach((title) => {
      const headerCell = this.headerCell(headerRow);
      headerCell.textContent = title;
    });
    const deleteHeaderCell = this.headerCell(headerRow);
    deleteHeaderCell.classList.add()
    deleteHeaderCell.textContent = "Borrar";
    const editHeaderCell = this.headerCell(headerRow);
    editHeaderCell.textContent = "Modificar";
  };

  this.addTbodyItem = function (data) {
    const tbody = $d.querySelector("tbody");
    data.forEach((userData) => {
      const row = this.row(tbody);

      Object.entries(userData).forEach(([key, value]) => {
        const cell = this.dataCell(row);
        cell.textContent = value;
      });
      const deleteCell = this.dataCell(row);
      const deletIcon=this.createDeleteIcon(deleteCell);
      const editCell = this.dataCell(row);
      const editIcon=this.createEditIcon(editCell);
      

    });
  };
  
  this.createDeleteIcon = function (parent) {
    const icono = $dc.icono(parent, "bi-trash3-fill");
    icono.classList.add("tr__icono--delet");
    icono.addEventListener("click", deletUser);

  };
  this.createEditIcon = function (parent) {
    const icono = $dc.icono(parent, "bi-pencil-square");
    icono.classList.add("tr__icono--edit");
    icono.addEventListener("click", function (e) {
      const userRow = e.target.parentNode.parentNode; // Obtiene la fila
      editUser(userRow);
    });
  };
  function deletUser(e) {
    let user = e.target.parentNode.parentNode;
    user.remove();
  }
  function editUser(userRow) {
    const data = {}; // Objeto para almacenar los datos del usuario
    userRow.querySelectorAll("td").forEach((cell, index) => {
      const keys = ["nombre", "dni", "email"];
      const key = keys[index]; // Obtiene el título de la celda (nombre, DNI, etc.)
      const value = cell.textContent; // Obtiene el valor de la celda
      data[key] = value;
      const form = $d.querySelector("form");
      form.elements["name-user"].value = data.nombre;
      form.elements["dni-user"].value = parseInt(data.dni);
      form.elements["mail-user"].value = data.email;
    });
  }
};
const $dt = new $$DomTable();
