import { Component, OnInit } from '@angular/core';
import { ProductoM } from 'src/app/models/Producto';
import { ProductoApiServiceService } from 'src/app/Services/producto-api-service.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-tabla-productos',
  templateUrl: './tabla-productos.component.html',
  styleUrls: ['./tabla-productos.component.css']
})
export class TablaProductosComponent implements OnInit {

  productos:Array<ProductoM> = [];
  error: string = '';
  totalItemxPage: number = 3;
  totalPage: number = 0;
  page: number = 1;
  fieldOrder: string = 'ninguno';
  orderAsc: boolean = false;
  orderNombre: boolean = false;
  orderCategoria: boolean = false;

  fieldFilter: string = '';
  criterioFilter: string = '';

  paginas: Array<number> = [];


  constructor(private prodService: ProductoApiServiceService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.filtrar();

    this.fieldOrder = 'ninguno';
    this.orderNombre = false;
    this.orderCategoria = false;
    this.orderAsc = false;
  }

  onDelete(id: number) {
    if (confirm('Are you sure want to delete id = ' + id)) {
      this.prodService.eliminarProducto(+id).subscribe(
        res => {
          this.showError('Producto ' + id + ' eliminado correctamente');
          this.filtrar();
        },
        error => this.error = error
      );
    }
  }

  showSuccess(message: string) {
    this.toastr.success(message, '');
  }

  showError(message: string) {
    this.toastr.error(message, '');
  }

  filtrar(){
    this.prodService.obtenerProductosFiltrados(this.fieldFilter, this.criterioFilter, this.fieldOrder, this.orderAsc, this.page, this.totalItemxPage).subscribe(
      res => {
        console.log(res);
        this.productos = res.productos as unknown as Array<ProductoM>;
        this.totalPage = res.totalPages;
        this.llenarPages();
      }
    );
  }

  ordenar(vorderfiled: string){
    if(this.fieldOrder === vorderfiled){
      this.orderAsc = !this.orderAsc;
    }
    else{
      this.fieldOrder = vorderfiled;
      if(vorderfiled === 'Nombre'){
        this.orderNombre = true;
        this.orderCategoria = false;
        this.orderAsc = true;
      }
      else{
        this.orderNombre = false;
        this.orderCategoria = true;
        this.orderAsc = true;
      }
    }
  }

  llenarPages() {
    this.paginas = [];
    for (let index = 1; index <= this.totalPage; index++) {
      this.paginas.push(index);
    }
  }

  setPage(pagina: number){
    this.page = pagina;
    this.filtrar();
  }

  nextPage(){
    if((this.page + 1) <= this.totalPage)
      this.setPage(this.page + 1);
  }

  previusPage(){
    if((this.page - 1) >= 1)
      this.setPage(this.page - 1);
  }

}



