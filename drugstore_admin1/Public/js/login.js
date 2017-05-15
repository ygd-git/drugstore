/* 
* @Author: anchen
* @Date:   2017-04-11 21:00:03
* @Last Modified by:   anchen
* @Last Modified time: 2017-04-11 21:00:13
*/

$(document).ready(function(){
    $('#register_a').click(function(event) {
            $('#register_toggle').click();
        });
        var register_form =  $('form#register_form');
        register_form.submit(function(e){
            var account = register_form.find('[name=account]').val();
            var password = register_form.find('[name=password]').val();
            var password_confirm = register_form.find('[name=password_confirm]').val();
            if (account && password_confirm && password) {
                if (password_confirm === password) {
                    //可以提交了
                }
                else{
                    e.preventDefault();
                    alert('俩次密码输入不一致!');
                }
                
            }else{
                e.preventDefault();
                alert('请填写完整');
            }
            
        });

        var login_form = $('form#login_form');
        login_form.submit(function(event) {
            var account = login_form.find('[name=account]').val();
            var password = login_form.find('[name=password]').val();
            if (account && password) {
                //可以提交了
            }else{
                event.preventDefault();
                alert('请填写完整!')
            }
        });
});