const $$Nav=function(){

    this.init = () => {
        $ds.nav("body");
        $dn.makeButton("Inicio",$ds.home);
        $dn.makeButton("Carrera",$f.addUser);
        $dn.makeButtonLogin("Ingresar")
        $dn.makeDropDown("Funciones",["abm usuario","otro btn"],[$f.addUser,$f.addUser]);

    }

}

const $nav=new $$Nav