$(document).ready(function () {
    BuscarProdutos();
});

var BuscarProdutos = function () {
    var url = $("#UrlAPI").val() + "/Produtos/GetAll";

    $.ajax({
        url: url,
        contentType: 'application/json',
        method: 'GET',
        dataType: 'json',
        success: function (retorno) {
            var tbody = $("#tbodyProdutos");
            tbody.html('');
            retorno.forEach((produto) => {
                tbody.append(`
                    <tr id="${produto.id}">
                        <td>${produto.nome}</td>
                        <td>${produto.status ? "Ativo" : "Inativo"}</td>
                        <td class="text-center">
                            <a href="javascript:EditarProduto(${produto.id})" class="mx-2" title="Editar"><i class="text-info fa fa-pen"></i></a>
                            <a href="javascript:DeletarProduto(${produto.id})" class="mx-2" title="Deletar"><i class="text-danger fa fa-trash"></i></a>
                        </td>
                    </tr>
                `)
            });
        }
    })
}

function CadastrarProduto() {
    $("#ModalCadastro").modal();
}

$("#BtnCadastrarProduto").click(function () {
    var status = $("#StatusProdutoCadastrar").val() == '1' ? true : false;
    var url = $("#UrlAPI").val() + "/Produtos/Create?nome=" + $("#NomeProdutoCadastrar").val() + "&status=" + status;

    $.ajax({
        url: url,
        contentType: 'application/json',
        method: 'Put',
        success: function (retorno) {
            if (retorno) {
                Swal.fire({
                    title: 'Tudo certo!',
                    text: 'Produto criado com sucesso',
                    icon: 'success',
                    confirmButtonText: 'Ok'
                }).then(function () {
                    window.location.reload();
                });
            }
            else {
                Swal.fire({
                    title: 'Ops!',
                    text: 'Não foi possível criar esse produto.',
                    icon: 'error',
                    confirmButtonText: 'Ok'
                }).then(function () {
                    window.location.reload();
                });
            }
        }
    })
});

function EditarProduto(idProduto) {
    $("#IdProdutoEditar").val(idProduto);
    var url = $("#UrlAPI").val() + "/Produtos/Get";
    $.ajax({
        url: url,
        contentType: 'application/json',
        method: 'Get',
        data: { id: idProduto },
        success: function (retorno) {
            if (retorno.id > 0) {
                $("#NomeProdutoEditar").val(retorno.nome);
                if (retorno.status) {
                    $("#StatusProdutoEditar").val('1');
                }
                else {
                    $("#StatusProdutoEditar").val('0');
                }
            }
            else {
                Swal.fire({
                    title: 'Ops!',
                    text: 'Não foi possível selecionar esse produto.',
                    icon: 'error',
                    confirmButtonText: 'Ok'
                }).then(function () {
                    window.location.reload();
                });
            }
        }
    })
    $("#ModalEditar").modal();
}

$("#BtnEditarProduto").click(function () {
    var status = $("#StatusProdutoEditar").val() == '1' ? true : false;
    var url = $("#UrlAPI").val() + "/Produtos/Update?id=" + $("#IdProdutoEditar").val() + "&nome=" + $("#NomeProdutoEditar").val() + "&status=" + status;

    $.ajax({
        url: url,
        method: 'Post',
        success: function (retorno) {
            if (retorno) {
                Swal.fire({
                    title: 'Tudo certo!',
                    text: 'Produto atualizado com sucesso',
                    icon: 'success',
                    confirmButtonText: 'Ok'
                }).then(function () {
                    window.location.reload();
                });
            }
            else {
                Swal.fire({
                    title: 'Ops!',
                    text: 'Não foi possível atualizar esse produto.',
                    icon: 'error',
                    confirmButtonText: 'Ok'
                }).then(function () {
                    window.location.reload();
                });
            }
        }
    })
});


function DeletarProduto(idProduto) {
    $("#IdProdutoDeletar").val(idProduto);
    $("#ModalDeletar").modal();

}

$("#BtnDeletarProduto").click(function () {
    var url = $("#UrlAPI").val() + "/Produtos/Delete?id=" + $("#IdProdutoDeletar").val();

    $.ajax({
        url: url,
        contentType: 'application/json',
        method: 'Delete',
        success: function (retorno) {
            if (retorno) {
                Swal.fire({
                    title: 'Tudo certo!',
                    text: 'Produto deletado com sucesso',
                    icon: 'success',
                    confirmButtonText: 'Ok'
                }).then(function () {
                    window.location.reload();
                });
            }
            else {
                Swal.fire({
                    title: 'Ops!',
                    text: 'Não foi possível deletar esse produto.',
                    icon: 'error',
                    confirmButtonText: 'Ok'
                }).then(function () {
                    window.location.reload();
                });
            }
        }
    })
});

