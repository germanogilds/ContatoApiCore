using System;
using System.Collections.Generic;
using med.domain;

namespace med.service
{
	public interface IContatoService
	{
	void SalvarContato(Contato model );
    List<Contato> GetAll();
    Contato GetById(int id);
    void Update(Contato model);
    void Delete(Contato model);

	}
}