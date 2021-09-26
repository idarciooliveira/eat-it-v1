using EAT.Infrastruture.WPF.Models;

namespace MenuModule.ViewModels
{
    public class AboutBase : ViewModelBase
    {
        public string StartUpDevelopersInfor()
        {
            return $"Os Jovens Idárcio Oliveira Filipe e Eliseu Oscar Itombe são " +
                   "dois estudantes do curso Técninco de Informática do Colégio Dom Domingos Franque," +
                   " ambos natural de Cabinda eles, durante a sua formação técnica, tiveram" +
                   " uma brilhante ideia de criar uma Plataforma de Refeições Online" +
                   " na qual denominaram Eat-It, Ideia essa que surgiu" +
                   " da necessidade que as pessoas daquela região têm" +
                   " em conseguir boas refeições sem sair de casa, assim não era preciso ter que" +
                   " enfrentar engarafamnetos e outros problemas que dessa mesma deslocação pode causar.";
        }
        public string StartUpPlataformInfor()
        {
            return $"EAT-IT Aplication\nVersão 2.0 (Compilação da aplicação 1.402.201)\n" +
                    "© 2017 IOF Development. Todos os direitos reservados.\n" +
                    "A EAT - IT Aplication e a sua interface de usuário são protegidas por uma marca\n" +
                    "registradas e outros direitos de propriedade intelectual existentes ou\n" +
                    "pendestes em Angola e em outros países/regiões.";
        }
    }
}