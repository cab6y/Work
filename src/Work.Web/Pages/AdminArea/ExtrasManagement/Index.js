$(document).ready(function () {
    var l = abp.localization.getResource('Work');

    var dataTable = $("#ExtrasTable").DataTable(

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
            ajax: abp.libs.datatables.createAjax(work.extras.extra.getList),

            columnDefs: [
                {
                    orderable: false,
                    title: "Dosya",
                    data: "imgUrl",
                    className: 'text-center',
                    render: function (data, type, full, meta) {
                        return '<img src="/' + data + '" style="width:150px;height:75px;"/>';
                    }
                },

                {
                    title: l('name'),
                    data: "name"
                },
                {
                    title: l('surname'),
                    data: "surname"
                },
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [

                                {
                                    text: l('AllVideo'),
                                    confirmMessage: function (data) {

                                    },
                                    action: function (data) {
                                        work.extras.extra
                                            .getAllVideos(data.record.id)
                                            .then(function (result) {
                                                $.each(result, function (index, value) {
                                                    window.open("/"+value, '_blank');
                                                });
                                            });
                                    }
                                }
                            ]
                    }
                }

            ]

        })

    );


});
