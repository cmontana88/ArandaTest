import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup, FormControl, NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Producto, ProductoM } from '../../models/Producto'
import { ProductoApiServiceService } from '../../Services/producto-api-service.service'
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-crear-producto',
  templateUrl: './crear-producto.component.html',
  styleUrls: ['./crear-producto.component.css']
})
export class CrearProductoComponent implements OnInit {

  rutaImagenVacia: string = './../../../assets/ImagenVacia.png';
  producto: Producto = new Producto;
  submitted: boolean = false;
  requiredImage: boolean = true;
  productoForm!: FormGroup;

  error: string = '';
  uploadError: string = '';
  imagePath: string = '';
  pageTitle: string = '';

  constructor(private fb: FormBuilder, private prodService: ProductoApiServiceService, private router: Router, private route: ActivatedRoute, private toastr: ToastrService) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.pageTitle = 'Actualizar Producto';
      this.requiredImage = false;
      this.prodService.obtenerProducto(+id).subscribe(res => {
        this.producto.Id = res.id;
        this.producto.Nombre = res.nombre;
        this.producto.Descripcion = res.descripcion;
        this.producto.Categoria = res.categoria;
        this.producto.Imagen = res.imagen;
        this.producto.ImagenBase64 = res.imagenBase64;

        this.imagePath = this.producto.ImagenBase64;
      });
    } else {
      this.pageTitle = 'Crear Producto';
      this.requiredImage = true;
      this.imagePath = this.rutaImagenVacia;
    }

  }

  onSelectedFile(event: any) {
    const file = event.target.files[0];
    const reader = new FileReader();
    if(typeof file !== 'undefined'){
      reader.readAsDataURL(file);
      reader.onload = () => {
      this.imagePath = String(reader.result);
      this.producto.ImagenBase64 = this.imagePath;
      };
    }
    else{
      this.imagePath = this.rutaImagenVacia;
      this.producto.ImagenBase64 = '';
    }

  }

  guardarProducto(producto: NgForm): void {

    if(producto.valid){
      if(this.producto.Id > 0){
        this.prodService.actualizarProducto(this.producto, this.producto.Id).subscribe(res => {
          if (res.status === 'error') {
            this.uploadError = res.message;
            this.showError(this.uploadError);
          } else {
            this.showSuccess('Producto actualizado con exito');
            this.router.navigate(['/']);
          }
        },
        error => this.error = error);
      }
      else{
        this.prodService.crearProducto(this.producto).subscribe(res => {
          if (res.status === 'error') {
            this.uploadError = res.message;
            this.showError(this.uploadError);
          } else {
            this.showSuccess('Producto creado con exito');
            this.router.navigate(['/']);
          }
        },
        error => this.error = error);
      }
    }
    else{
      this.showError('Producto no valido');
    }

  }

  showSuccess(message: string) {
    this.toastr.success(message, '');
  }

  showError(message: string) {
    this.toastr.error(message, '');
  }
}
