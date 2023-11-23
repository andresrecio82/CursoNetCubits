<script setup lang="ts">
import { ref,onMounted } from 'vue'

import Column from 'primevue/column'
import DataTable from 'primevue/datatable'


let userlist = ref([])

const getUserList = async () =>
{
  const response = await fetch('http://localhost:5000/api/User') 
  const data = await response.json()
  userlist.value =  data.userlist
}

onMounted(async ()=>{
  await getUserList()
});

</script>

<template>
  <div class="mb-3"></div>
    <div class="grid">
      <div class="col-12">
        <DataTable :value="userlist">
          <Column field="firsName" header="Nombre"></Column>
          <Column field="lastName" header="Apellido"></Column>
        </DataTable>
      </div>
    </div>
</template>
