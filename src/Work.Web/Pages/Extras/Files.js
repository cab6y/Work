$(document).ready(function () {
    var l = abp.localization.getResource('Work');
    var createModal = new abp.ModalManager(abp.appPath + 'Extras/CreateFileModal');
    var dataTable = $('#FileTable').DataTable(

        abp.libs.datatables.normalizeConfiguration({
            autoWidth: true,
            processing: true,
            responsive: true,
            colReorder: true,
            serverSide: true,
            retrieve: true,
            destroy: true,
            paging: true,
            info: true,
            bInfo: false,
            bFilter: false,
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(work.files.extraFile.getList),

            columnDefs: [
                
                {
                    title: l('name'),
                    data: "name"
                },
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Delete'),
                                    action: function (data) {
                                        work.files.extraFile
                                            .delete(data.record.id)
                                            .then(function () {
                                                abp.notify.info(
                                                    l('SuccessfullyDeleted')
                                                );
                                                dataTable.ajax.reload();
                                            });
                                    }
                                }
                            ]
                    }
                },

            ]

        })

    );
    
    createModal.onResult(function () {
        dataTable.ajax.reload();
    });
    $('#NewFile').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
