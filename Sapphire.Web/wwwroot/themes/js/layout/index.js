var os, main_vm = new Vue({
    el: '#mainapp',
    data: {
        menulist: [],
        messList: [],
        messCount: 0,
        isDown: false,
        isThemeShow: false,
        themeName: 'default',
        siteList: []
    },
    created: function () {
        var that = this;
        document.querySelector('body').addEventListener('click', function (e) {
            if (e.target.id === 'notificdown' || e.target.id === 'notificicon') {
                that.isDown = true;
            } else {
                that.isDown = false;
            }
            if (e.target.id === 'themedown' || e.target.id === 'themeicon') {
                that.isThemeShow = true;
            } else {
                that.isThemeShow = false;
            }
        });
    },
    methods: {
        clearCache: function () {
            os.success('这里是测试，可以ajax到后台清除网站缓存');
        },
        godown: function () {
            this.isDown = this.isDown ? false : true;
        },
        selectTheme: function () {
            this.isThemeShow = this.isThemeShow ? false : true;
        },
        logout: function () {
            os.load();
            os.ajax('api/admin/logout', null, function (res) {
                if (res.statusCode === 200) {
                    window.location.href = res.data;
                } else {
                    os.error(res.message);
                }
            });
        },
        qhSite: function (m) {
            os.load();
            os.ajax('api/admin/rep/site', m, function (res) {
                if (res.statusCode === 200) {
                    window.location.reload();
                } else {
                    os.error(res.message);
                }
            });
        }
    }
});
var rm_vm = new Vue({
    el: '#rmapp',
    data: {
        tmlist: [],
        list: []
    }
});
layui.config({
    base: '/themes/js/modules/'
}).use(['element', 'layer', 'jquery', 'common', 'pjax'], function () {
    var element = layui.element
        , $ = layui.jquery;
    os = layui.common;
    //加载站点列表
    os.ajax('api/cmssite/list', {}, function (res) {
        if (res.statusCode === 200) {
            main_vm.siteList = res.data;
        } else {
            os.error(res.message);
        }
    });
    os.ajax('api/menu/authmenu', null, function (res) {
        if (res.statusCode === 200) {
            $.each(res.data, function (index, item) {
                if (item.layer === 1) {
                    main_vm.menulist.push(item);
                }
            });
            rm_vm.tmlist = main_vm.menulist;
            rm_vm.list = res.data;
            main_vm.$nextTick(function () {
                element.render();
                //定位到菜单
                $(".layui-bg-black .Sapphire-nav-tree li a").each(function () {
                    if (window.location.pathname === $(this).attr('href')) {
                        $(".layui-bg-black .Sapphire-nav-tree li").removeClass('layui-nav-itemed');
                        $(this).parents('.layui-nav-item').addClass('layui-nav-itemed');
                        $(this).parent().addClass('layui-this');
                    }
                });
                $(".load8").fadeOut(200);
                element.on('nav(topmenu)', function (elem) {
                    var that = $(elem);
                    var topIndex = that.data('index');
                    $("#rmapp .layui-side-scroll ul").addClass('layui-hide');
                    $("#rmapp .layui-side-scroll ul").eq(topIndex).removeClass('layui-hide');
                });
                $("#rmapp .layui-side-scroll ul").eq(0).removeClass('layui-hide');
            });
        } else {
            $(".load8").fadeOut(200);
            os.error(res.message);
        }
    },'get');
    $.pjax({
        url: '/Sapphireadmin/default',
        container: '#main-container',
        fragment: '#container'
    });
    $('.layui-layout-admin').pjax('a[data-pjax]', '#main-container',
        {
            fragment: "#container",
            cache: false,
            show: 'fade'
        }
    );
    main_vm.themeName = os.GetSession("SapphireADMIN_THEME") ?? 'default';
    $(".theme-item").click(function () {
        var color = $(this).data('css');
        $(".theme-color").attr('href', '/themes/css/theme/' + color + '.css');
        main_vm.isThemeShow = false;
        main_vm.themeName = color;
        os.SetSession('SapphireADMIN_THEME', color);
        os.ajax('api/admin/theme', { parm: color }, function (res) { });
    });
    $(document).on('pjax:start', function () { NProgress.start(); $(".load8").show(); });
    $(document).on('pjax:end', function () { NProgress.done(); $(".load8").fadeOut(200); });
});