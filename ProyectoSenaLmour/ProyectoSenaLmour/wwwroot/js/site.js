// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
window.addEventListener('DOMContentLoaded', event => {

    // Toggle the side navigation
    const sidebarToggle = document.body.querySelector('#sidebarToggle');
    if (sidebarToggle) {
        // Uncomment Below to persist sidebar toggle between refreshes
        // if (localStorage.getItem('sb|sidebar-toggle') === 'true') {
        //     document.body.classList.toggle('sb-sidenav-toggled');
        // }
        sidebarToggle.addEventListener('click', event => {
            event.preventDefault();
            document.body.classList.toggle('sb-sidenav-toggled');
            localStorage.setItem('sb|sidebar-toggle', document.body.classList.contains('sb-sidenav-toggled'));
        });


        var table = new DataTable('#rolesTable', {
            language: {
                url: '//cdn.datatables.net/plug-ins/2.0.3/i18n/es-CO.json',
            },
        });

        var table = new DataTable('#usersTable', {
            language: {
                url: '//cdn.datatables.net/plug-ins/2.0.3/i18n/es-CO.json',
            },
        });




        var table = new DataTable('#customerTable', {
            language: {
                url: '//cdn.datatables.net/plug-ins/2.0.3/i18n/es-CO.json',
            },
        });


        var table = new DataTable('#roomTable', {
            language: {
                url: '//cdn.datatables.net/plug-ins/2.0.3/i18n/es-CO.json',
            },
        });


        var table = new DataTable('#packageTable', {
            language: {
                url: '//cdn.datatables.net/plug-ins/2.0.3/i18n/es-CO.json',
            },
        });


        var table = new DataTable('#serviceTable', {
            language: {
                url: '//cdn.datatables.net/plug-ins/2.0.3/i18n/es-CO.json',
            },
        });

        var table = new DataTable('#bookingTable', {
            language: {
                url: '//cdn.datatables.net/plug-ins/2.0.3/i18n/es-CO.json',
            },
        });

        var table = new DataTable('#paymentTable', {
            language: {
                url: '//cdn.datatables.net/plug-ins/2.0.3/i18n/es-CO.json',
            },
        });


        var table = new DataTable('#PermissionTable', {
            language: {
                url: '//cdn.datatables.net/plug-ins/2.0.3/i18n/es-CO.json',
            },
        });



      
       

        
       

       /* este es para las graficas*/
        new Chart(document.getElementById("bar-chart"), {
            type: 'bar',
            data: {
                labels: ["Abonos", "Reservas", "Paquetes", "Servicios", "Usuario"],
                datasets: [
                    {
                        label: "Population (millions)",
                        backgroundColor: ["#3e95cd", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850"],
                        data: [2478, 5267, 734, 784, 433]
                    }
                ]
            },
            options: {
                legend: { display: false },
                title: {
                    display: true,
                    text: 'Predicted world population (millions) in 2050'
                }
            }
        });

    }


});


