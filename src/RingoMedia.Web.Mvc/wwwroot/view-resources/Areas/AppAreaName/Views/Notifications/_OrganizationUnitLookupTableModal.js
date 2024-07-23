(function ($) {
    app.modals.OrganizationUnitLookupTableModal = function () {
        var _modalManager;

        var _notificationService = abp.services.app.notification;
        var _$organizationUnitTable = $('#OrganizationUnitTable');

        this.init = function (modalManager) {
            _modalManager = modalManager;

            _modalManager.getModal().find('.save-button').click(function () {
                var selectedItems = dataTable.rows({selected: true}).data().toArray();
                _modalManager.setResult(selectedItems);
                _modalManager.close();
            });
        };

        var dataTable = _$organizationUnitTable.DataTable({
            paging: true,
            serverSide: true,
            processing: true,
            listAction: {
                ajaxFunction: _notificationService.getAllOrganizationUnitForLookupTable,
                inputFilter: function () {
                    return {
                        filter: $('#OrganizationUnitTableFilter').val(),
                    };
                },
            },
            columnDefs: [
                {
                    targets: 0,
                    data: null,
                    orderable: false,
                    defaultContent: '',
                    render: function (data) {
                        return (
                            '<label for="checkbox_' + data.value +'" class="checkbox form-check ms-5" style="width:50px">' +
                            '<input type="checkbox" id="checkbox_' +data.value +'" class="form-check-input" />&nbsp;' +
                            '<span class="form-check-label"></span>' +
                            '</label>'
                        );
                    },
                },
                {
                    autoWidth: false,
                    orderable: false,
                    targets: 1,
                    data: 'displayName',
                },
            ],
            select: {
                style: 'multi',
                info: false,
                selector: 'td:first-child label.checkbox input',
            }
        });
        
        function getOrganizationUnit() {
            dataTable.ajax.reload();
        }

        $('#GetOrganizationUnitButton').click(function (e) {
            e.preventDefault();
            getOrganizationUnit();
        });

        $(document).keypress(function (e) {
            if (e.which === 13) {
                getOrganizationUnit();
            }
        });
    };
})(jQuery);
