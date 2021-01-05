namespace Abc.Data.Common {

    public abstract class NamedEntityData : UniqueEntityData, IUniqueNamedData {

        public string Code { get; set; }
        public string Name { get; set; }

    }

}
